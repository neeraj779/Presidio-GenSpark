using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Add(Cart item)
        {
            if (item != null)
            {
                item.Id = GenerateId();
                items.Add(item);
                return item;
            }
            throw new ArgumentNullException(nameof(item), "Cannot add a null cart to the repository.");
        }

        private int GenerateId()
        {
            if (items.Count == 0)
            {
                return 1;
            }
            return items.Last().Id + 1;
        }

        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.Id == key);
            if (cart != null)
            {
                return cart;
            }
            throw new NullReferenceException($"No cart found with key: {key}");
        }

        public override Cart Update(Cart item)
        {
            Cart existingCart = GetByKey(item.Id);
            if (existingCart != null)
            {
                existingCart = item;
            }
            return existingCart;
        }
    }
}
