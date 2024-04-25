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

        public Customer AddCustomer(Customer newCustomer)
        {
            return _customerRepository.Add(newCustomer);
        }

        public Customer DeleteCustomer(Customer customerToDelete)
        {
            try
            {
                return _customerRepository.Delete(customerToDelete.Id);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                return _customerRepository.GetByKey(customerId);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            try
            {
                return _customerRepository.Update(customerToUpdate);
            }
            catch (NoCustomerWithGivenIdException)
            {
                throw new NoCustomerWithGivenIdException();
            }
        }



    }
}
