using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        public Task<Cart> AddCart(Cart cart, int customerId);
        Task<Cart> GetCart(int id);
        Task<List<CartItem>> GetAllCartItemDetails(int id);
        Task<Cart> AddCartItem(int CartId, CartItem cartItem);
        Task<Cart> UpdateCartItem(int CartId, CartItem cartItem);
        Task<Cart> DeleteCartItem(int CartId, CartItem cartItem);
        Task<Cart> CalculateTotalPrice(Cart cart);
        Task<Cart> DeleteCart(Cart cart);
        Task<Cart> DeleteAllCartItems(Cart cart);
    }
}