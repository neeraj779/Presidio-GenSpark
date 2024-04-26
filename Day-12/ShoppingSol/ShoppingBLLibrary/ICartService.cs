using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        public Cart AddCart(Cart cart, int customerId);
        public Cart GetCart(int id);
        public List<CartItem> GetAllCartItemDetails(int id);
        public Cart AddCartItem(int CartId, CartItem cartItem);
        public Cart UpdateCartItem(int CartId, CartItem cartItem);
        public Cart DeleteCartItem(int CartId, CartItem cartItem);
        public Cart CalculateTotalPrice(Cart cart);
        public Cart DeleteCart(Cart cart);
        public Cart DeleteAllCartItems(Cart cart);
    }
}