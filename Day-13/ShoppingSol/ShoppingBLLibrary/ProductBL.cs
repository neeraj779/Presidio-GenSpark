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

        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.Add(product);
        }


        public Task<Product> DeleteProduct(int id)
        {
            return _productRepository.Delete(id);
        }

        public async Task<Product> EditProduct(Product product)
        {
            try
            {
                return await _productRepository.Update(product);
            }
            catch
            {
                throw new NoProductWithGivenIdException();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products.ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetByKey(id);
            }
            catch
            {
                throw new NoProductWithGivenIdException();
            }
        }
    }
}
