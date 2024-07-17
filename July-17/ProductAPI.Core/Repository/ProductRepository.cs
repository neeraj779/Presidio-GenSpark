using Microsoft.EntityFrameworkCore;
using ProductAPI.Core.Contexts;
using ProductAPI.Core.Interfaces;
using ProductAPI.Core.Models.DBModels;

namespace ProductAPI.Core.Repository
{
    public class ProductRepository : IRepository
    {
        private readonly ProductAPIContext _context;

        public ProductRepository(ProductAPIContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            var student = await _context.Products.ToListAsync();
            return student;
        }
    }
}
