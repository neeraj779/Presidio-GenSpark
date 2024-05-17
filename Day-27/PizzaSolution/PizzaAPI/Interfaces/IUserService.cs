using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO user);
        public Task<User> Register(UserRegisterDTO user);
        public Task<IEnumerable<UserReturnDTO>> GetAllUsers();
        public Task<UserReturnDTO> ActivateUser(int id);
        public Task<UserReturnDTO> DeactivateUser(int id);
    }
}
