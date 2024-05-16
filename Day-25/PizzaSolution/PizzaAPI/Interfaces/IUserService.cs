using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO user);
        public Task<User> Register(UserLoginDTO user);
    }
}
