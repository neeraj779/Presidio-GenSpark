using ShoppingBLLLibrary;
using ShoppingModelLibrary;

namespace ShoppingBusinessLogic
{
    public class ShoppingBL : IShoppingServices
    {
        public ShoppingBL() { }
        public double CalculateTotalPrice(List<Product> products)
        {
            double totalPrice = products.Sum(p => p.Price * p.QuantityInHand);

            if (totalPrice < 100)
                totalPrice += 100.0;

            if (products.Count == 3 && totalPrice >= 1500.0)
                totalPrice *= (1 - 0.05);

            return totalPrice;
        }

        public bool ValidateCart(List<CartItem> cartItems)
        {
            foreach (var p in cartItems)
            {
                if (p.Quantity > 5)
                    return false;
            }
            return true;
        }
    }
}
