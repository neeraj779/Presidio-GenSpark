using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartItemService
    {
        public Task<CartItem> AddCartItem(CartItem cartItem, int productId);
        public bool CheckProductAvailability(CartItem cartItem, Product product);
        public Task<CartItem> CalculateCost(CartItem cartItem, Product product);
        public Task<CartItem> UpdateCartItem(CartItem PrevCartItems, CartItem cartItem);
        public Task<CartItem> DeleteCartItem(CartItem cartItem);
    }
}