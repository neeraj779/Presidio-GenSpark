using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }


        [HttpPost("RaiseRequest")]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Request>> Register(RequestDTO requestDTO)
        {
            try
            {
                Request result = await _requestService.RaiseRequest(requestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [HttpGet("GetRequests")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> GetRequest()
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                if (employeeId == null)
                {
                    throw new NotLoggedInException();
                }

                var result = await _requestService.GetRequestsByEmployeeID(Convert.ToInt32(employeeId));
                return Ok(result);
            }
            catch (NoRequestFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
    }
}