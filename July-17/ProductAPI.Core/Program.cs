using Microsoft.EntityFrameworkCore;
using ProductAPI.Core.Contexts;
using ProductAPI.Core.Interfaces;
using ProductAPI.Core.Repository;
using ProductAPI.Core.Services;
using ProductAPI.Core.Utils;

namespace ProductAPI.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var azureUtils = new AzureUtils();
            var connectionString = azureUtils.GetConnectionString();


            #region Context
            builder.Services.AddDbContext<ProductAPIContext>(
                options => options.UseSqlServer(connectionString)
                );
            #endregion

            #region Repository
            builder.Services.AddScoped<IRepository, ProductRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IProductServices, ProductSevices>();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
