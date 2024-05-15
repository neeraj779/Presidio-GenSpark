using PizzaAPI.Models;
using PizzaAPI.Interfaces;

namespace PizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
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
                throw new Exception("Pizza not found");
            }
            if (!pizza.IsAvailable)
            {
                throw new Exception("Pizza not available");
            }
            return pizza;
        }
    }

}
