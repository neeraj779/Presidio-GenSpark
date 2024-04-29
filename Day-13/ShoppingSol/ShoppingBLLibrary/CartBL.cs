using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartService
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IRepository<int, Customer> _customerRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IRepository<int, Product> _productRepository;

        public CartBL(
            IRepository<int, Cart> cartRepository,
            IRepository<int, Customer> customerRepository,
            ICartItemRepository cartItemRepository,
            IRepository<int, Product> productRepository
            )
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<Cart> AddCart(Cart cart, int customerId)
        {
            var customer = await _customerRepository.GetByKey(customerId);

            if (customer == null)
                throw new NoCustomerWithGivenIdException();

            cart.Customer = customer;
            cart.CustomerId = customer.Id;

            return await _cartRepository.Add(cart);
        }

        public async Task<Cart> GetCart(int id)
        {
            var cart = await _cartRepository.GetByKey(id);

            if (cart == null)
                throw new NoCartWithGivenIdException();

            return cart;
        }

        public async Task<Cart> AddCartItem(int cartId, CartItem cartItem)
        {
            cartItem.CartId = cartId;
            _cartItemRepository.Update(cartItem);

            var cart = await GetCart(cartId);

            cart.CartItems.Add(cartItem);
            var updatedCart = await CalculateTotalPrice(cart);

            return await _cartRepository.Update(updatedCart);
        }

        public async Task<Cart> CalculateTotalPrice(Cart cart)
        {
            double totalCost = 0;
            int totalQuantity = 0;

            foreach (var cartItem in cart.CartItems)
            {
                totalCost += cartItem.Price;
                totalQuantity += cartItem.Quantity;
            }

            if (totalQuantity == 3 && totalCost >= 1500)
                cart.Discount = 5;

            if (totalCost < 100)
                cart.ShippingCharges = 100;

            cart.TotalPrice = cart.ShippingCharges + (totalCost - (totalCost * (cart.Discount / 100)));

            return cart;
        }

        public async Task<Cart> UpdateCartItem(int cartId, CartItem cartItem)
        {
            var cart = await GetCart(cartId);

            if (!cart.CartItems.Exists(ci => ci.ProductId == cartItem.ProductId))
                throw new NoCartItemWithGivenProductIdException();

            for (int i = 0; i < cart.CartItems.Count; i++)
            {
                if (cart.CartItems[i].ProductId == cartItem.ProductId)
                    cart.CartItems[i] = cartItem;
            }

            var updatedCart = await CalculateTotalPrice(cart);

            return await _cartRepository.Update(updatedCart);
        }

        public async Task<Cart> DeleteCartItem(int cartId, CartItem cartItem)
        {
            var cart = await GetCart(cartId);

            if (!cart.CartItems.Contains(cartItem))
                throw new NoCartItemWithGivenProductIdException();

            cart.CartItems.Remove(cartItem);

            var updatedCart = await CalculateTotalPrice(cart);

            return await _cartRepository.Update(updatedCart);
        }

        public async Task<Cart> DeleteAllCartItems(Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                var product = await _productRepository.GetByKey(cartItem.ProductId);
                product.QuantityInHand += cartItem.Quantity;
                await _productRepository.Update(product);
                _cartItemRepository.Delete(cartItem.CartId, cartItem.ProductId);
            }

            cart.CartItems.Clear();
            var updatedCart = await CalculateTotalPrice(cart);

            return await _cartRepository.Update(updatedCart);
        }

        public async Task<Cart> DeleteCart(Cart cart)
        {
            cart = await DeleteAllCartItems(cart);
            return await _cartRepository.Delete(cart.Id);
        }

        public async Task<List<CartItem>> GetAllCartItemDetails(int id)
        {
            List<CartItem> CartItems = new List<CartItem>();
            Cart cart = await _cartRepository.GetByKey(id);
            CartItems = cart.CartItems;

            if (CartItems == null)
                throw new NoCartItemsFoundException();

            return CartItems;
        }
    }
}