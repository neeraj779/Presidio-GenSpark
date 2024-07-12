using ATMApplication.Models;

namespace ATMApplication.Repositories
{
    public class CustomerRepository : AbstractRepositoryClass<int, Customer>
    {
        public CustomerRepository(ATMContext context) : base(context)
        {
        }
        
    }
}
