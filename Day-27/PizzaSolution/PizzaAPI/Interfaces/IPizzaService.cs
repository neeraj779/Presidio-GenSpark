using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetPizzas();
        public Task<IEnumerable<Pizza>> GetAvailablePizzas();
        public Task<Pizza> OrderPizza(int id);
        public Task<Pizza> AddPizza(Pizza pizza);
    }
}
