using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartItemService
    {
        public CartItem AddCartItem(CartItem cartItem, int productId);
        public bool CheckProductAvailability(CartItem cartItem, Product product);
        public CartItem CalculateCost(CartItem cartItem, Product product);
        public CartItem UpdateCartItem(CartItem PrevCartItems, CartItem cartItem);
        public CartItem DeleteCartItem(CartItem cartItem);
    }
}