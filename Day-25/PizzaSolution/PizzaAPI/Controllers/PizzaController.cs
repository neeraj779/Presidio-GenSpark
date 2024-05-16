using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Exceptions;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// Retrieves all pizzas.
        /// </summary>
        [HttpGet("GetAllPizza")]
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _pizzaService.GetPizzas();
        }

        /// <summary>
        /// Retrieves all available pizzas.
        /// </summary>
        [HttpGet("GetAvailablePizza")]
        public async Task<IEnumerable<Pizza>> GetAvailablePizzas()
        {
            return await _pizzaService.GetAvailablePizzas();
        }

        /// <summary>
        /// Places an order for a pizza.
        /// </summary>
        [Authorize]
        [HttpPost("OrderPizza")]
        public async Task<ActionResult<Pizza>> OrderPizza(int id)
        {
            try
            {
                return await _pizzaService.OrderPizza(id);
            }

            catch (NoSuchPizzaException ex)
            {
                return BadRequest(new ErrorModel { ErrorCode = StatusCodes.Status401Unauthorized, Message = ex.Message });
            }
            catch (PizzaNotAvailableException ex)
            {
                return BadRequest(new ErrorModel { ErrorCode = StatusCodes.Status401Unauthorized, Message = ex.Message });
            }
        }
    }
}
