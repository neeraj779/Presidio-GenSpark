using SimpleBankingModelLibrary;
using SimpleBankingDALibrary;

namespace SimpleBankingBLLibrary
{
    public class BankingBL : IBankingServices
    {
        private readonly IUserRepo _userRepository;
        private readonly ITransactionRepo _transactionRepository;

        public BankingBL(IUserRepo userRepository, ITransactionRepo transactionRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }

        public void RegisterUser(string username, double initialBalance)
        {
            if (_userRepository.GetUserByUsername(username) != null)
            {
                Console.WriteLine("Username already exists. Please choose a different one.");
                return;
            }

            var newUser = new User { Username = username, Balance = initialBalance };
            _userRepository.AddUser(newUser);
            Console.WriteLine("User registered successfully!");
        }

        public void Deposit(string username, double amount)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            user.Balance += amount;

            _transactionRepository.AddTransaction(new Transaction { SenderUsername = username, ReceiverUsername = username, Amount = amount, Timestamp = DateTime.Now });
            Console.WriteLine($"Deposit of {amount} successful.");
        }

        public void Withdraw(string username, double amount)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (user.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            user.Balance -= amount;
            _transactionRepository.AddTransaction(new Transaction { SenderUsername = username, ReceiverUsername = username, Amount = -amount, Timestamp = DateTime.Now });
            Console.WriteLine($"Withdrawal of {amount} successful. New balance: {user.Balance}");
        }

        public void Transfer(string sender, string receiver, double amount)
        {
            var senderUser = _userRepository.GetUserByUsername(sender);
            var receiverUser = _userRepository.GetUserByUsername(receiver);

            if (senderUser == null || receiverUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (senderUser.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            senderUser.Balance -= amount;
            receiverUser.Balance += amount;
            _transactionRepository.AddTransaction(new Transaction { SenderUsername = sender, ReceiverUsername = receiver, Amount = amount, Timestamp = DateTime.Now });
            Console.WriteLine($"Transfer of {amount} from {sender} to {receiver} successful.");
        }

        public double CheckBalance(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            return user?.Balance ?? -1;
        }

        public void CheckTransactionHistory(string username)
        {
            var transactions = _transactionRepository.GetTransactionsByUsername(username);
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            Console.WriteLine($"Transaction history for {username}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"{transaction.Timestamp} - {transaction.SenderUsername} -> {transaction.ReceiverUsername}: {transaction.Amount}");
            }
        }
    }
}
