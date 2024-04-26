using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLTest
{
    public class CartBLTest
    {
        IRepository<int, Cart> CartRepository;

        [SetUp]
        public void Setup()
        {
            CartRepository = new CartRepository();
            List<CartItem> cartItems = new List<CartItem>();

            CartItem cartItem1 = new CartItem()
            {
                ProductId = 1,
                CartId = 1,
                Quantity = 5,
                Price = 500,
                Discount = 0,
                PriceExpiryDate = Convert.ToDateTime("2026 - 01 - 01")
            };

            cartItems.Add(cartItem1);

            CartItem cartItem2 = new CartItem()
            {
                ProductId = 2,
                CartId = 2,
                Quantity = 5,
                Price = 500,
                Discount = 0,
                PriceExpiryDate = Convert.ToDateTime("2027 - 02 - 02")
            };
            cartItems.Add(cartItem2);

            Customer customer1 = new Customer() { Id = 1, Name = "John", Phone = "1234567899", Age = 22 };
            Cart cart = new Cart() { Customer = customer1, CustomerId = 1, CartItems = cartItems };


            CartRepository.Add(cart);
        }

        [Test]
        public void AddSuccessTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem()
            {
                ProductId = 1,
                CartId = 1,
                Quantity = 5,
                Price = 500,
                Discount = 0,
                PriceExpiryDate = Convert.ToDateTime("2026 - 01 - 01")
            };

            cartItems.Add(cartItem);

            Customer customer = new Customer() { Id = 1, Name = "XYZ", Phone = "1234567899", Age = 21 };
            Cart cart = new Cart() { Customer = customer, CustomerId = 3, CartItems = cartItems };

            // Action 
            var result = CartRepository.Add(cart);

            // Assert
            Assert.That(result.Id, Is.EqualTo(2));
        }

        [Test]
        public void AddFailTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem()
            {
                ProductId = 6,
                CartId = 6,
                Quantity = 5,
                Price = 5000,
                Discount = 0,
                PriceExpiryDate = Convert.ToDateTime("2026 - 01 - 01")
            };

            cartItems.Add(cartItem);

            Customer customer = new Customer() { Id = 2, Name = "XYZ", Phone = "1234567899", Age = 21 };

            Cart cart = new Cart() { Customer = customer, CustomerId = 1, CartItems = cartItems };

            // Action 
            var exception = Assert.Throws<DuplicateCartException>(() => CartRepository.Add(cart));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Cart already exists."));
        }


        [Test]
        public void DeleteSuccessTest()
        {
            // Action 
            var result = CartRepository.Delete(1);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void DeleteFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartRepository.Delete(5));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No Cart with the given ID was found."));
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            // Action 
            var result = CartRepository.GetByKey(1);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetByKeyFailTest()
        {
            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartRepository.GetByKey(100));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No Cart with the given ID was found."));
        }

        [Test]
        public void UpdateSuccessTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();
            CartItem cartItem = new CartItem()
            {
                ProductId = 1,
                CartId = 1,
                Quantity = 5,
                Price = 500,
                Discount = 0,
                PriceExpiryDate = Convert.ToDateTime("2026 - 01 - 01")
            };
            cartItems.Add(cartItem);

            Customer customer = new Customer() { Id = 1, Name = "XYZ", Phone = "1234567899", Age = 21 };
            Cart cart = new Cart() { Id = 1, Customer = customer, CustomerId = 1, CartItems = cartItems };

            // Action 
            var result = CartRepository.Update(cart);

            // Assert
            Assert.That(result.CartItems[0].Quantity, Is.EqualTo(5));
        }

        [Test]
        public void UpdateFailTest()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>();

            Customer customer = new Customer() { Id = 1, Name = "XYZ", Phone = "1234567899", Age = 21 };
            Cart cart = new Cart() { Id = 7, Customer = customer, CustomerId = 1, CartItems = cartItems };

            // Action 
            var exception = Assert.Throws<NoCartWithGivenIdException>(() => CartRepository.Update(cart));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No Cart with the given ID was found."));
        }

        [Test]
        public void GetAllSuccessTest()
        {
            // Action 
            var result = CartRepository.GetAll();

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}