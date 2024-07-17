using Microsoft.EntityFrameworkCore;
using ProductAPI.Core.Models.DBModels;

namespace ProductAPI.Core.Contexts
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
