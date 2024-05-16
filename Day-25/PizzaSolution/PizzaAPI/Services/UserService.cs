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
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository<int, User> userRepo, ITokenService tokenService) 
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
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
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.AccessToken = _tokenService.GenerateToken(userDB);
            returnDTO.TokenType = "Bearer";
            return returnDTO;
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
