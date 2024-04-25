using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem cartItem = GetByKey(key);
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override CartItem GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(c => c.CartId == key);
            return cartItem;
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartItem = GetByKey(item.CartId);
            if (cartItem != null)
            {
                cartItem = item;
            }
            return cartItem;
        }
    }
}