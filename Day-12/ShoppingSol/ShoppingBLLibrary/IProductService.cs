using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public List<Product> GetAll();
        public Product GetProductById(int id);
        public Product EditProduct(Product product);
        public Product DeleteProduct(Product product);
    }
}