using ATMApplication.Models;

namespace ATMApplication.Repositories
{
    public class AccountRepository : AbstractRepositoryClass<int, Account>
    {
        public AccountRepository(ATMContext context) : base(context)
        {
        }
    }
}
