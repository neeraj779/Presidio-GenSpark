using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<User>> Register(UserRegisterDTO user)
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

        /// <summary>
        /// Get all users.
        /// </summary>
        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel { ErrorCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// Activate a user.
        /// </summary>
        [HttpPut("ActivateUser")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> ActivateUser(int id)
        {
            try
            {
                var result = await _userService.ActivateUser(id);
                return Ok(result);
            }
            catch (NoSuchUserException ex)
            {
                return BadRequest(new ErrorModel { ErrorCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deactivate a user.
        /// </summary>
        [HttpPut("DeactivateUser")]
        [Authorize]
        public async Task<ActionResult<User>> DeactivateUser(int id)
        {
            try
            {
                var result = await _userService.DeactivateUser(id);
                return Ok(result);
            }
            catch (NoSuchUserException ex)
            {
                return BadRequest(new ErrorModel { ErrorCode = StatusCodes.Status400BadRequest, Message = ex.Message });
            }
        }
    }
}
