using ProductAPI.Core.Exceptions;
using ProductAPI.Core.Interfaces;
using ProductAPI.Core.Models.DBModels;
using ProductAPI.Core.Models.DTOs;

namespace ProductAPI.Core.Services
{
    public class ProductSevices : IProductServices
    {
        private readonly IRepository _productRepository;

        public ProductSevices(IRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            if (!products.Any())
            {
                throw new NoProductsFoundException();
            }

            return products.Select(MapProductsToProductDTO).ToList();

        }

        private ProductDTO MapProductsToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
