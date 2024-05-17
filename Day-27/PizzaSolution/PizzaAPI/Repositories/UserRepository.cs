using Microsoft.EntityFrameworkCore;
using PizzaAPI.Contexts;
using PizzaAPI.Exceptions;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Repositories
{
    public class UserRepository : IUserRepository<int, User>
    {
        private PizzaContext _context;

        public UserRepository(PizzaContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            item.Status = "Inactive";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> Get(int key)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == key);
            return user;
        }

        public async Task<User> GetByUserName(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            return user;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.Id);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchUserException();
        }
    }
}
