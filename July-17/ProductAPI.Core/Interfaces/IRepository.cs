using ProductAPI.Core.Models.DBModels;

namespace ProductAPI.Core.Interfaces
{
    public interface IRepository
    {
        public Task<IEnumerable<Product>> GetAll();
    }
}
