using ATMApplication.Models.DTOs;

namespace ATMApplication.Services
{
    public interface IAuthenticationService
    {
        public Task<int> AuthenticateCard(AuthenticationDTO authenticationDTO);
    }
}
