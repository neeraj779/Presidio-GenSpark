using SimpleBankingModelLibrary;

namespace SimpleBankingDALibrary
{
    public interface ITransactionRepo
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetTransactionsByUsername(string username);
    }
}
