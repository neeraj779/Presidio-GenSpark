using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public interface ICartItemRepository
    {
        public CartItem Add(CartItem item);
        public ICollection<CartItem> GetAll();
        public CartItem GetByKey(int CartId, int productId);
        public CartItem Update(CartItem item);
        public CartItem Delete(int CartId, int productId);
    }
}