using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Customer> _customerRepository;

        public CustomerService(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            return await _customerRepository.Add(newCustomer);
        }

        public Task<Customer> DeleteCustomer(int id)
        {
            return _customerRepository.Delete(id);
        }

        public Task<Customer> GetCustomer(int id)
        {
            return _customerRepository.GetByKey(id);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            try
            {
                return await _customerRepository.GetByKey(customerId);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customerToUpdate)
        {
            try
            {
                return await _customerRepository.Update(customerToUpdate);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
        }
    }
}
