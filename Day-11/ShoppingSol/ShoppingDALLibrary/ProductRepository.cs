using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                throw new NoCustomerWithGiveIdException();
            }
            return product;

        }

        public override Product Update(Product item)
        {
            Product product = GetByKey(item.Id);
            if (product != null)
            {
                product.Id = item.Id;
                product.Name = item.Name;
                product.Price = item.Price;
                product.Image = item.Image;
                product.QuantityInHand = item.QuantityInHand;
            }
            return product;

        }
    }
}
