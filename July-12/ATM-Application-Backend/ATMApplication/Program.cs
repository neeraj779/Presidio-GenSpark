using ATMApplication.Models;
using ATMApplication.Repositories;
using ATMApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace ATMApplication
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
            builder.Services.AddDbContext<ATMContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
            
            builder.Services.AddScoped<IRepository<int, Account>, AccountRepository>(); 
            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>(); 
            builder.Services.AddScoped<IRepository<int, Card>, CardRepository>(); 
            builder.Services.AddScoped<IRepository<Guid, Transaction>, TransactionRepository>(); 

            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("CorsPolicy");


            app.Run();
        }
    }
}
