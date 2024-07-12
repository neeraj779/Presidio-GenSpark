using ATMApplication.Exceptions;
using ATMApplication.Models;
using ATMApplication.Models.DTOs;
using ATMApplication.Repositories;
using ATMApplication.Services;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace ATMApplication.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IRepository<int, Account> _accountRepository;
        private readonly IRepository<Guid, Transaction> _transactionRepository;

        public TransactionService(IRepository<Guid, Transaction> transactionRepo, IRepository<int, Account> accountRepo, IAuthenticationService authenticationService)
        {
            _transactionRepository = transactionRepo;
            _accountRepository = accountRepo;
            _authenticationService = authenticationService;
        }

        public async Task<List<ReturnTransactionDTO>> GetTransactionHistory(AuthenticationDTO authenticationDTO)
        {
            try
            {
                int CustomerId = await _authenticationService.AuthenticateCard(authenticationDTO);
                var AllTransactions = await _transactionRepository.GetAll();
                var transactions = new List<Transaction>();
                foreach (var transaction in AllTransactions)
                {
                    var account = await _accountRepository.GetById(transaction.AccountId);
                    if (account.CustomerID == CustomerId)
                        transactions.Add(transaction);
                }
                if (transactions.Count == 0)
                {
                    throw new NoEntitiesFoundException("No transactions found!");
                }
                var result = new List<ReturnTransactionDTO>();
                foreach (var transaction in transactions)
                {
                    result.Add(await MapTransactionToReturnTransactionDTO(transaction));
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        private async Task<ReturnTransactionDTO> MapTransactionToReturnTransactionDTO(Transaction transaction)
        {
            ReturnTransactionDTO returnTransactionDTO = new ReturnTransactionDTO();
            returnTransactionDTO.Id = transaction.Id;
            var account = await _accountRepository.GetById(transaction.AccountId);
            returnTransactionDTO.AccountNo = account.AccountNo;
            returnTransactionDTO.Amount = transaction.Amount;
            returnTransactionDTO.Time = transaction.Time;
            returnTransactionDTO.Type = transaction.Type.ToString();
            return returnTransactionDTO;
        }

        public async Task<DepositReturnDTO> Deposit(DepositDTO depositDto)
        {
            try
            {
                int customerId = await _authenticationService.AuthenticateCard(depositDto.authDetails);
                var accounts = await _accountRepository.GetAll();
                var account = accounts.SingleOrDefault(a => a.CustomerID == customerId);
                if (depositDto.amount > 20000)
                {
                    throw new DepositAmoutExceedExption();
                }
                if (account != null)
                {
                    Transaction t = new Transaction()
                    {
                        Amount = depositDto.amount,
                        Time = DateTime.Now,
                        Type = TransactionTypeEnum.TransactionType.Deposit,
                        AccountId = account.AccountId
                    };
                    await _transactionRepository.Add(t);
                    account.Balance += depositDto.amount;
                    await _accountRepository.Update(account);
                    return new DepositReturnDTO
                    {
                        Success = true,
                        AccountNo = account.AccountNo,
                        CutomerId = customerId
                    };
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Withdraw(WithdrawalDTO withdrawalDTO, int customerId)
        {
            var accounts = await _accountRepository.GetAll();
            var account = accounts.SingleOrDefault(a => a.CustomerID == customerId);

            if (account == null)
            {
                throw new EntityNotFoundException("Account not found!");
            }

            if (withdrawalDTO.Amount > 10000)
            {
                throw new InvalidOperationException("Cannot withdraw more than 10000 in one transaction.");
            }

            if (account.Balance < withdrawalDTO.Amount)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            account.Balance -= withdrawalDTO.Amount;
            await _accountRepository.Update(account);

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = withdrawalDTO.Amount,
                Time = DateTime.Now,
                Type = TransactionTypeEnum.TransactionType.Withdrawal,
                AccountId = account.AccountId
            };

            await _transactionRepository.Add(transaction);

            return true;
        }
    }
}
