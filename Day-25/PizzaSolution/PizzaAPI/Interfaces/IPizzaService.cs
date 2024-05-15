using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetPizzas();
        public Task<Pizza> OrderPizza(int id);
    }
}
