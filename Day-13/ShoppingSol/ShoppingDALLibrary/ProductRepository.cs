using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override async Task<Product> Delete(int key)
        {
            Product product = await GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                throw new NoCustomerWithGivenIdException();
            }
            return product;

        }

        public override async Task<Product> Update(Product item)
        {
            Product product = await GetByKey(item.Id);
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
