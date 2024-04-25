using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CartService : ICartService
    {
        private readonly IRepository<int, Cart> _cartRepository;

        public CartService(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        }

        public Cart AddCart(Cart cart, Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            cart.Customer = customer;
            Cart newCart = _cartRepository.Add(cart);
            return newCart;
        }

        public Cart GetCart(int id)
        {
            try
            {
                return _cartRepository.GetByKey(id);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
        }

        public Cart AddCartItem(int cartId, CartItem cartItem)
        {
            if (cartItem == null)
                throw new ArgumentNullException(nameof(cartItem));

            Cart cart = _cartRepository.GetByKey(cartId);

            if (cart.CartItems.Count >= 5)
                throw new CartCapacityExceededException();

            cart.CartItems.Add(cartItem);
            cart.TotalPrice = CalculateTotalPrice(cart);

            Cart updatedCart = _cartRepository.Update(cart);
            return updatedCart;
        }

        public double CalculateTotalPrice(Cart cart)
        {
            if (cart == null || cart.CartItems == null)
                return 0.0;

            double totalPrice = 0.0;

            foreach (var item in cart.CartItems)
            {
                totalPrice += item.Price * item.Quantity;
            }

            if (totalPrice < 100)
                totalPrice += 100.0;

            if (cart.CartItems.Count == 3 && totalPrice >= 1500.0)
                totalPrice *= (1 - 0.05);

            return totalPrice;
        }

        public Cart DeleteCart(Cart cart)
        {
            try
            {
                return _cartRepository.Delete(cart.Id);
            }
            catch (NoCartWithGivenIdException)
            {
                throw new NoCartWithGivenIdException();
            }
        }

        public List<CartItem> GetAllCartItemDetails(int id)
        {
            Cart cart = _cartRepository.GetByKey(id);
            return cart?.CartItems;
        }
    }
}
