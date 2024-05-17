using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
