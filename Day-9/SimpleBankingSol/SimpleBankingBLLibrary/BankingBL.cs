using System.Security.Cryptography;
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

        public void RegisterUser(string username, double initialBalance, string password)
        {
            if (_userRepository.GetUserByUsername(username) != null)
                throw new UserAlreadyExistsException();

            byte[] salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);
            var newUser = new User { Username = username, Balance = initialBalance, Password = hashedPassword };
            _userRepository.AddUser(newUser);
            Console.WriteLine("User registered successfully!");
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations: 5000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
                Buffer.BlockCopy(hash, 0, hashBytes, 16, 20);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
                return false;

            byte[] storedSalt = Convert.FromBase64String(user.Password).Take(16).ToArray();
            string hashedPassword = HashPassword(password, storedSalt);
            return user.Password == hashedPassword;
        }

        public void Deposit(string username, double amount)
        {
            var user = GetUserIfExists(username);
            user.Balance += amount;

            RecordTransaction(username, username, amount);
            Console.WriteLine($"Deposit of {amount} successful.");
        }

        public void Withdraw(string username, double amount)
        {
            var user = GetUserIfExists(username);
            if (user.Balance < amount)
                throw new InsufficientFundsException();

            user.Balance -= amount;
            RecordTransaction(username, username, -amount);
            Console.WriteLine($"Withdrawal of {amount} successful. New balance: {user.Balance}");
        }

        public void Transfer(string sender, string receiver, double amount)
        {
            var senderUser = GetUserIfExists(sender);
            var receiverUser = GetUserIfExists(receiver);

            if (senderUser.Balance < amount)
                throw new InsufficientFundsException();

            senderUser.Balance -= amount;
            receiverUser.Balance += amount;
            RecordTransaction(sender, receiver, amount);
            Console.WriteLine($"Transfer of {amount} from {sender} to {receiver} successful.");
        }

        private User GetUserIfExists(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
                throw new UserNotFoundException();
            return user;
        }

        private void RecordTransaction(string sender, string receiver, double amount)
        {
            _transactionRepository.AddTransaction(new Transaction { SenderUsername = sender, ReceiverUsername = receiver, Amount = amount, Timestamp = DateTime.Now });
        }

        public double CheckBalance(string username)
        {
            var user = GetUserIfExists(username);
            return user.Balance;
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
