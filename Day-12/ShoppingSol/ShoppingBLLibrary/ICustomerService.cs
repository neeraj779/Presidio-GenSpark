using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        public Customer AddCustomer(Customer customer);
        public Customer GetCustomerById(int id);
        public Customer UpdateCustomer(Customer customer);
        public Customer DeleteCustomer(Customer customer);

    }
}