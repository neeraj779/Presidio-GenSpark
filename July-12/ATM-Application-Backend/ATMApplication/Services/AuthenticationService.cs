using ATMApplication.Exceptions;
using ATMApplication.Models.DTOs;
using ATMApplication.Models;
using ATMApplication.Repositories;

namespace ATMApplication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<int, Card> _cardRepo;
        public AuthenticationService(IRepository<int, Card> cardRepo)
        {
            _cardRepo = cardRepo;
        }
        
        public async Task<int> AuthenticateCard(AuthenticationDTO authenticationDTO)
        {
            var cards = await _cardRepo.GetAll();
            if (cards.Count == 0)
                throw new InvalidCredentialsException("Invalid Credentials");
            var card = cards.SingleOrDefault(c => c.CardNumber == authenticationDTO.CardNumber);
            if(card == null)
                throw new InvalidCredentialsException("Invalid Credentials");
            if(card.Pin == authenticationDTO.Pin)
                return card.CustomerID;
            throw new InvalidCredentialsException("Invalid Credentials");
        }
    }
}
