using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("GetAllPizza")]
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _pizzaService.GetPizzas();
        }

        [HttpPost("OrderPizza")]
        public async Task<Pizza> OrderPizza(int id)
        {
            return await _pizzaService.OrderPizza(id);
        }
    }
}
