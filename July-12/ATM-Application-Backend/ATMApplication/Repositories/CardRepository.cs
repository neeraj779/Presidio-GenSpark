using ATMApplication.Models;

namespace ATMApplication.Repositories
{
    public class CardRepository : AbstractRepositoryClass<int, Card>
    {
        public CardRepository(ATMContext context) : base(context)
        {
        }
    }
}
