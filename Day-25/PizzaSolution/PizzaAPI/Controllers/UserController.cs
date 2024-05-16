using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Exceptions;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Controllers
{
    [Route("api/auth/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Logs in a user.
        /// </summary>
        [HttpPost("Login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO user)
        {
            try
            {
                var result = await _userService.Login(user);
                return Ok(result);
            }

            catch(UnauthorizedUserException ex)
            {
                return Unauthorized(new ErrorModel { ErrorCode = StatusCodes.Status401Unauthorized, Message = ex.Message });
            }

            catch (UserNotActiveException ex)
            {
                return Unauthorized(new ErrorModel { ErrorCode = StatusCodes.Status401Unauthorized, Message = ex.Message });
            }
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        [HttpPost("Register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register(UserLoginDTO user)
        {
            try
            {
                var result = await _userService.Register(user);
                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel { ErrorCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

    }
}
