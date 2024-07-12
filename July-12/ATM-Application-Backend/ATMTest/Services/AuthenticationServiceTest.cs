using ATMApplication.Exceptions;
using ATMApplication.Models;
using ATMApplication.Models.DTOs;
using ATMApplication.Repositories;
using ATMApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest.Services
{
    public class AuthenticationServiceTest
    {
        ATMContext context;
        IAuthenticationService authService;
        IRepository<int, Card> cardRepo;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("AuthenticationDB");
            context = new ATMContext(optionsBuilder.Options);
            cardRepo = new CardRepository(context);
            authService = new AuthenticationService(cardRepo);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AuthenticationSuccessTest()
        {
            // Arrange
            await cardRepo.Add(new Card { Id = 1, CardNumber = "AAA111", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now.AddDays(3), CustomerID = 1, Pin = "1111" });
            AuthenticationDTO authenticationDTO = new AuthenticationDTO {CardNumber = "AAA111", Pin = "1111"};

            // Action
            var result = await authService.AuthenticateCard(authenticationDTO);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AuthenticationWrongPinFailTest()
        {
            // Arrange
            await cardRepo.Add(new Card { Id = 1, CardNumber = "AAA111", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now.AddDays(3), CustomerID = 1, Pin = "1111" });
            AuthenticationDTO authenticationDTO = new AuthenticationDTO { CardNumber = "BBB111", Pin = "1111" };

            // Action
            var exception = Assert.ThrowsAsync<InvalidCredentialsException>(() => authService.AuthenticateCard(authenticationDTO));
        }
        
        [Test]
        public async Task AuthenticationWrongCardFailTest()
        {
            // Arrange
            await cardRepo.Add(new Card { Id = 1, CardNumber = "AAA111", CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now.AddDays(3), CustomerID = 1, Pin = "1111" });
            AuthenticationDTO authenticationDTO = new AuthenticationDTO { CardNumber = "AAA111", Pin = "2222" };

            // Action
            var exception = Assert.ThrowsAsync<InvalidCredentialsException>(() => authService.AuthenticateCard(authenticationDTO));
        }
    }
}
