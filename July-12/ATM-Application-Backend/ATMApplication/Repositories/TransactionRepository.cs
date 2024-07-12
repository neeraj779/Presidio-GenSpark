using ATMApplication.Models;

namespace ATMApplication.Repositories
{
    public class TransactionRepository : AbstractRepositoryClass<Guid, Transaction>
    {
        public TransactionRepository(ATMContext context) : base(context)
        {
        }
    }
}
