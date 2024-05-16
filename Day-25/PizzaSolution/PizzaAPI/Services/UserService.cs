using PizzaAPI.Exceptions;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<int, User> _userRepo;
        public UserService(IUserRepository<int, User> userRepo) 
        {
            _userRepo = userRepo;
        }

        public async Task<User> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.GetByUserName(loginDTO.UserName);
            if (userDB == null)
            {
                throw new UnauthorizedUserException();
            }

            if(userDB.Status != "Active")
            {
                throw new UserNotActiveException();
            }

            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            bool isPasswordCorrect = encrypterPass.SequenceEqual(userDB.Password);

            if (!isPasswordCorrect)
            {
                throw new UnauthorizedUserException();
            }

            return userDB;
        }

        public async Task<User> Register(UserLoginDTO user)
        {
            var existingUser = await _userRepo.GetByUserName(user.UserName);
            if (existingUser != null)
            {
                throw new DuplicateUserException();
            }

            User newUser = new User();

            HMACSHA512 hMACSHA = new HMACSHA512();
            newUser.UserName = user.UserName;
            newUser.PasswordHashKey = hMACSHA.Key;
            newUser.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(user.Password));

            newUser.Status = "Active";

            return await _userRepo.Add(newUser);
        }
    }
}
