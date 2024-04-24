using RequestTrackerModelLibrary;
namespace RequestTrackerApplication
{
    internal class Company
    {
        public void EmployeeClientVisit(IClientInteraction clientInteraction)
        {
            clientInteraction.GetPayment();
        }
    }
}