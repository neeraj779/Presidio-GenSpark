using ProductAPI.Core.Models.DTOs;

namespace ProductAPI.Core.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
