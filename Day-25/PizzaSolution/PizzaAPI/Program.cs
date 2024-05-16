using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaAPI.Contexts;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI
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
            builder.Services.AddSwaggerGen(
                async c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Pizza API",
                        Version = "v1",
                        Description = "API for managing Pizza Shop.",
                        Contact = new OpenApiContact
                        {
                            Name = "Neeraj",
                            Url = new Uri("https://github.com/neeraj779/Presidio-GenSpark/tree/main/Day-25/PizzaSolution/PizzaAPI")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        },
                    });

                    var xmlPath = Path.Combine("PizzaAPI.xml");
                    c.IncludeXmlComments(xmlPath);
                });


            #region Context
            builder.Services.AddDbContext<PizzaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped<IUserRepository<int, User>, UserRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            builder.Services.AddScoped<IUserService, UserService>();
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
