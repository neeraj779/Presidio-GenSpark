using ShoppingBLLLibrary;
using ShoppingBusinessLogic;
using ShoppingModelLibrary;

namespace ShoppingBLLTest
{
    public class ShoppingBLTest
    {
        IShoppingServices shoppingServices;

        [SetUp]
        public void Setup()
        {
            shoppingServices = new ShoppingBL();
        }

        [Test]
        public void CalculateTotalPriceTest()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1", Price = 100.0, QuantityInHand = 1 },
                new Product { Id = 2, Name = "Product2", Price = 200.0, QuantityInHand = 1 },
                new Product { Id = 3, Name = "Product3", Price = 300.0, QuantityInHand = 1 }
            };

            double totalPrice = shoppingServices.CalculateTotalPrice(products);
            Assert.That(totalPrice, Is.EqualTo(600.0));
        }

        [Test]
        public void CalculateTotalPriceDiscountTest()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1", Price = 1000.0, QuantityInHand = 1 },
                new Product { Id = 2, Name = "Product2", Price = 500.0, QuantityInHand = 1 },
                new Product { Id = 3, Name = "Product3", Price = 1000.0, QuantityInHand = 1 }
            };

            double totalPrice = shoppingServices.CalculateTotalPrice(products);
            Assert.That(totalPrice, Is.EqualTo(2375.0));
        }

        [Test]
        public void calculateTotalPriceLessThan100Test()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1", Price = 10.0, QuantityInHand = 1 },
                new Product { Id = 2, Name = "Product2", Price = 20.0, QuantityInHand = 1 },
                new Product { Id = 3, Name = "Product3", Price = 30.0, QuantityInHand = 1 }
            };

            double totalPrice = shoppingServices.CalculateTotalPrice(products);
            Assert.That(totalPrice, Is.EqualTo(160.0));
        }   

        [Test]
        public void ValidateCartTest()
        {
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 2 },
                new CartItem { ProductId = 2, Quantity = 3 },
                new CartItem { ProductId = 3, Quantity = 4 }
            };

            bool result = shoppingServices.ValidateCart(cartItems);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateCartFailTest()
        {
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem { ProductId = 1, Quantity = 2 },
                new CartItem { ProductId = 2, Quantity = 6 },
                new CartItem { ProductId = 3, Quantity = 4 }
            };

            bool result = shoppingServices.ValidateCart(cartItems);
            Assert.That(result, Is.False);
        }
    }
}