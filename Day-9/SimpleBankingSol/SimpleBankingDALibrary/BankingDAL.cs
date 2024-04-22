using SimpleBankingModelLibrary;

namespace SimpleBankingDALibrary
{
    public class BankingDALUser : IUserRepo
    {
        public static List<User> Users = new List<User>();

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public User GetUserByUsername(string username)
        {
            return Users.Find(u => u.Username == username);
        }
    }
    public class BankingDALTransaction : ITransactionRepo
    {

        public static List<Transaction> Transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public List<Transaction> GetTransactionsByUsername(string username)
        {
            return Transactions.FindAll(t => t.SenderUsername == username || t.ReceiverUsername == username);
        }
    }
}