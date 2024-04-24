using SimpleBankingDALibrary;
using SimpleBankingBLLibrary;

namespace SimpleBankingApp
{
    public class BankingMenu
    {
        private readonly IBankingServices _bankingOperations;
        private bool _loggedIn = false;
        private string _loggedInUsername = "";

        public BankingMenu(IBankingServices bankingOperations)
        {
            _bankingOperations = bankingOperations;
        }

        public void ShowMenu()
        {
            while (true)
            {
                if (!_loggedIn)
                {
                    PrintLoginMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    ProcessLoginChoice(choice);
                }
                else
                {
                    PrintMainMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    ProcessMainChoice(choice);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void PrintLoginMenu()
        {
            Console.WriteLine("Welcome to Simple Banking App");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register User");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("Welcome to Simple Banking App");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Check Transaction History");
            Console.WriteLine("6. Logout");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }

        private void ProcessMainChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Deposit();
                    break;
                case 2:
                    Withdraw();
                    break;
                case 3:
                    Transfer();
                    break;
                case 4:
                    CheckBalance();
                    break;
                case 5:
                    checkTransactionHistory();
                    break;
                case 6:
                    Logout();
                    break;
                case 7:
                    Console.WriteLine("Thankyou for using Simple Banking App.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void ProcessLoginChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    RegisterUser();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using Simple Banking App.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void Login()
        {
            string username = ReadUsername("Enter username: ");
            string? password = ReadPassword("Enter password: ");
            if (_bankingOperations.AuthenticateUser(username, password))
            {
                Console.WriteLine("Login successful.");
                _loggedIn = true;
                _loggedInUsername = username;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }

        private void Logout()
        {
            _loggedIn = false;
            _loggedInUsername = "";
            Console.WriteLine("Logged out successfully.");
        }

        private void RegisterUser()
        {
            string username = ReadUsername("Enter username: ");
            double initialBalance = ReadPositiveDouble("Enter initial balance: ");
            string password = ReadUsername("Enter password: ");
            try
            {
                _bankingOperations.RegisterUser(username, initialBalance, password);
            }
            catch (UserAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void Deposit()
        {
            string username = _loggedInUsername;
            double amount = ReadPositiveDouble("Enter amount to deposit: ");
            try
            {
                _bankingOperations.Deposit(username, amount);
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void Withdraw()
        {
            string username = _loggedInUsername;
            double amount = ReadPositiveDouble("Enter amount to withdraw: ");
            try
            {
                _bankingOperations.Withdraw(username, amount);
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void Transfer()
        {
            string sender = _loggedInUsername;
            string receiver = ReadUsername("Enter receiver username: ");
            double amount = ReadPositiveDouble("Enter amount to transfer: ");
            try
            {
                _bankingOperations.Transfer(sender, receiver, amount);
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void CheckBalance()
        {
            string username = _loggedInUsername;
            try
            {
                double balance = _bankingOperations.CheckBalance(username);
                Console.WriteLine($"Account balance for {username}: {balance}");
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private string ReadUsername(string prompt)
        {
            Console.Write(prompt);
            string? username = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Invalid input. Please enter a valid username.");
                username = Console.ReadLine();
            }
            return username;
        }

        private string ReadPassword(string prompt)
        {
            Console.Write(prompt);
            string? password = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Invalid input. Please enter a valid password.");
                password = Console.ReadLine();
            }
            return password;
        }

        private double ReadPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }
        }

        private void checkTransactionHistory()
        {
            string username = _loggedInUsername;
            _bankingOperations.CheckTransactionHistory(username);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepo userRepository = new BankingDALUser();
            ITransactionRepo transactionRepository = new BankingDALTransaction();
            IBankingServices bankingOperations = new BankingBL(userRepository, transactionRepository);

            BankingMenu bankingMenu = new BankingMenu(bankingOperations);
            bankingMenu.ShowMenu();
        }
    }
}
