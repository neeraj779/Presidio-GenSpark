using EFCoreCodeFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstApp.Contexts
{

    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=9SXBBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbPizzaShop");
        }

        public DbSet<Pizza>? Pizzas { get; set; }

    }
}
