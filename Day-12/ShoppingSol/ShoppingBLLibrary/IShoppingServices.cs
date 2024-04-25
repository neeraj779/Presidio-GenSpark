using ShoppingModelLibrary;

namespace ShoppingBLLLibrary
{
    public interface IShoppingServices
    {
        double CalculateTotalPrice(List<Product> products);
        bool ValidateCart(List<CartItem> cartitems);
    }
}
