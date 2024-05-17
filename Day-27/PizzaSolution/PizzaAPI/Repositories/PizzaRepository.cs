using PizzaAPI.Models;
using PizzaAPI.Interfaces;
using PizzaAPI.Contexts;
using PizzaAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace PizzaAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaContext _context;

        public PizzaRepository(PizzaContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new NoSuchPizzaException();
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(d => d.Id == key);
            if (pizza == null)
            {
                throw new NoSuchPizzaException();
            }
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            return pizzas;
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.Id);
            if (pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new NoSuchPizzaException();
        }
    }
}
