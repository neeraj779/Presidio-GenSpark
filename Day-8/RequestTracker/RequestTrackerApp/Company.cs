using RequestTrackerModelLibrary;
namespace RequestTrackerApp
{
    internal class Company
    {
        public void EmployeeClientVisit(IClientInteraction clientInteraction)
        {
            clientInteraction.GetPayment();
        }
    }
}