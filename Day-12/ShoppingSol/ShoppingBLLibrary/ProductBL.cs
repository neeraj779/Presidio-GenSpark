using System.Collections.Generic;
using System.Linq;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class ProductBL : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;

        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product DeleteProduct(Product product)
        {
            try
            {
                return _productRepository.Delete(product.Id);
            }
            catch
            {
                throw new NoProductWithGivenIdException();
            }
        }

        public Product EditProduct(Product product)
        {
            try
            {
                return _productRepository.Update(product);
            }
            catch
            {
                throw new NoProductWithGivenIdException();
            }
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _productRepository.GetByKey(id);
            }
            catch
            {
                throw new NoProductWithGivenIdException();
            }
        }
    }
}
