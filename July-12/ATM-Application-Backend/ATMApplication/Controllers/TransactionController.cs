using ATMApplication.Exceptions;
using ATMApplication.Models;
using ATMApplication.Models.DTOs;
using ATMApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAuthenticationService _authenticationService;

        public TransactionController(ITransactionService transactionService, IAuthenticationService authenticationService)
        {
            _transactionService = transactionService;
            _authenticationService = authenticationService;
        }

        [HttpPost("GetAllTransactions")]
        [ProducesResponseType(typeof(List<ReturnTransactionDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<ReturnTransactionDTO>>> GetAllTransactions(AuthenticationDTO authenticationDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _transactionService.GetTransactionHistory(authenticationDTO);
                    return Ok(result);
                }
                catch (NoEntitiesFoundException nef)
                {
                    return NotFound(new ErrorModel(404, nef.Message));
                }
                catch (EntityNotFoundException enf)
                {
                    return NotFound(new ErrorModel(404, enf.Message));
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorModel(500, ex.Message));
                }
            }
            return BadRequest("All details are not provided. Please check the object");
        }

        [HttpPost]
        [Route("Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  async Task<ActionResult<DepositReturnDTO>> DepositAmount(DepositDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
               DepositReturnDTO returndto =  await _transactionService.Deposit(dto);
                return returndto;
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest); 
            }
            catch (InvalidCredentialsException)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (DepositAmoutExceedExption)
            {
                return StatusCode(StatusCodes.Status409Conflict); 
            }
            catch
            {
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError); 
            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawalDTO withdrawalDTO)
        {
            try
            {
                // Validate the model state
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Extract authentication details
                var cardNumber = withdrawalDTO.AuthDetails.CardNumber;
                var pin = withdrawalDTO.AuthDetails.Pin;

                // Authenticate the card
                var customerId = await _authenticationService.AuthenticateCard(new AuthenticationDTO
                {
                    CardNumber = cardNumber,
                    Pin = pin
                });

                // Perform the withdrawal
                bool result = await _transactionService.Withdraw(new WithdrawalDTO
                {
                    Amount = withdrawalDTO.Amount // Only pass the amount to the transaction service
                }, customerId);

                return Ok(new { success = result });
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
