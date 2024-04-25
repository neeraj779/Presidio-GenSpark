using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALTest
{
    public class CustomerDALTest
    {
        IRepository<int, Customer> customerRepository;


        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
        }

        [Test]
        public void CustomerAddSuccessTest()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepository.Add(customer);
            Customer customer1 = customerRepository.GetByKey(1);
            var result = customerRepository.GetAll();
            Assert.That(customer1, Is.EqualTo(customer));
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void CustomerUpdateSuccessTest()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepository.Add(customer);

            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 21 };
            customerRepository.Update(customer1);

            Customer customer2 = customerRepository.GetByKey(1);
            Assert.That(customer2.Age, Is.EqualTo(21));
        }

        [Test]
        public void CustomerDeleteSuccessTest()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepository.Add(customer);
            customerRepository.Delete(1);
            var result = customerRepository.GetAll();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void CustomerGetByKeySuccessTest()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepository.Add(customer);
            Customer customer1 = customerRepository.GetByKey(1);
            Assert.That(customer1, Is.EqualTo(customer));
        }

        [Test]
        public void CustomerGetByKeyFailureTest()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepository.Add(customer);
            Assert.Throws<NoCustomerWithGivenIdException>(() => customerRepository.GetByKey(2));
        }
    }
}