using PizzaAPI.Models;
using PizzaAPI.Interfaces;
using PizzaAPI.Exceptions;

namespace PizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Pizza>> GetAvailablePizzas()
        {
            var pizzas = await _repository.Get();
            pizzas = pizzas.Where(p => p.IsAvailable);
            return pizzas;

        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _repository.Get();
        }

        public async Task<Pizza> OrderPizza(int id)
        {
            var pizza = await _repository.Get(id);
            if (pizza == null)
            {
                throw new NoSuchPizzaException();
            }
            if (!pizza.IsAvailable)
            {
                throw new PizzaNotAvailableException();
            }
            return pizza;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            return await _repository.Add(pizza);
        }
    }

}
