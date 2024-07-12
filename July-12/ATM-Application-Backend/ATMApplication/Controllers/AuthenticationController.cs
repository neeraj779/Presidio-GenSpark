using ATMApplication.Exceptions;
using ATMApplication.Models.DTOs;
using ATMApplication.Models;
using ATMApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("AuthenticateCard")]
        [ProducesResponseType(typeof(List<ReturnTransactionDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<int>> AuthenticateCard(AuthenticationDTO authenticationDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int CustomerId = await _authenticationService.AuthenticateCard(authenticationDTO);
                    return Ok(CustomerId);
                }
                catch (InvalidCredentialsException ice)
                {
                    return Unauthorized(new ErrorModel(401, ice.Message));
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorModel(500, ex.Message));
                }
            }
            return BadRequest("All details are not provided. Please check the object");
        }
    }
}
