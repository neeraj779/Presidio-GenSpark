using Microsoft.EntityFrameworkCore;

namespace ATMApplication.Models
{
    public class ATMContext : DbContext
    {
        public ATMContext(DbContextOptions options) : base(options)
        {
        }
        
        DbSet<Card> Cards { get; set; } 
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Ram", Gender = "Male", Age = 22, Phone = "9999999999", Address = "Chennai" });
            modelBuilder.Entity<Card>().HasData(
                new Card { Id = 1, CardNumber = "378282246310005", CustomerID = 1, CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now.AddDays(10), Pin = "9999" }
            );
        }

    }
}
