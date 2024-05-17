using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;

namespace PizzaAPI.Contexts
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Pepperoni",
                    Price = 150,
                    IsAvailable = true
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Margherita",
                    Price = 200,
                    IsAvailable = true
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Hawaiian",
                    Price = 250,
                    IsAvailable = false
                }
          );
        }
    }
}
