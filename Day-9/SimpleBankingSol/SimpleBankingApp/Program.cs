using System;
using SimpleBankingDALibrary;
using SimpleBankingBLLibrary;

namespace SimpleBankingApp
{
    public class BankingMenu
    {
        private readonly IBankingServices _bankingOperations;

        public BankingMenu(IBankingServices bankingOperations)
        {
            _bankingOperations = bankingOperations;
        }

        public void ShowMenu()
        {
            while (true)
            {
                PrintMainMenu();
                int choice = Convert.ToInt32(Console.ReadLine());
                ProcessChoice(choice);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("Welcome to Simple Banking App");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Check Balance");
            Console.WriteLine("6. Check Transaction History");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }

        private void ProcessChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    RegisterUser();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    Transfer();
                    break;
                case 5:
                    CheckBalance();
                    break;
                case 6:
                    checkTransactionHistory();
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

        private void RegisterUser()
        {
            string username = ReadUsername("Enter username: ");
            double initialBalance = ReadPositiveDouble("Enter initial balance: ");
            try
            {
                _bankingOperations.RegisterUser(username, initialBalance);
            }
            catch (UserAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void Deposit()
        {
            string username = ReadUsername("Enter username: ");
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
            string username = ReadUsername("Enter username: ");
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
        }

        private void Transfer()
        {
            string sender = ReadUsername("Enter sender username: ");
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
        }

        private void CheckBalance()
        {
            string username = ReadUsername("Enter username: ");
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
            string username = ReadUsername("Enter username: ");
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
