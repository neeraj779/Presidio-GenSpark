using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> GetCustomer(int id);
        public Task<Customer> UpdateCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(int id);

    }
}