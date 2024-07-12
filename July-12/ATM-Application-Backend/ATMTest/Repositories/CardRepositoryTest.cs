using ATMApplication.Models;
using ATMApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest.Repositories
{
    public class CardRepositoryTest
    {
        DbContextOptionsBuilder optionsBuilder;
        IRepository<int, Card> _cardRepository;
        IRepository<int, Customer> _customerRepository;
        Customer c = null;
        [SetUp]
        public async Task Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("AtmTest");
            var context = new ATMContext(optionsBuilder.Options);
            _cardRepository = new CardRepository(context);
            _customerRepository = new CustomerRepository(context);
            c = new Customer() { Id = 1, Name = "Test Customer", Age = 21, Address = "Test Address", Phone = "999999999", Gender = "Male" };
        }

        [Test]
        public async Task AddCard()
        {
            Card card = new Card()
            {
                Id = 101,
                CardNumber = "121212121212",
                CustomerID = 1,
                Pin = "0000",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
            };

            var res = await _cardRepository.Add(card);

            Assert.IsNotNull(res);

        }
        [Test]
        public async Task GetCarByIdTest()
        {
            var card = new Card()
            {
                Id = 5,
                CardNumber = "121212121212",
                CustomerID = 1,
                Pin = "0000",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
            };
            var addedCard = await _cardRepository.Add(card);
            var res = await _cardRepository.GetById(5); 
            Assert.IsNotNull(res);
        }

        [Test]  
        public async Task UpdateCardTest()
        {
            //await _customerRepository.Add(c);
            var card = new Card()
            {
                Id = 3,
                CardNumber = "121212121212",
                CustomerID = 1,
                Pin = "0000",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
            };
            var addedCard = await _cardRepository.Add(card);
            addedCard.Pin = "1111"; 
            var res = await _cardRepository.Update(addedCard);
            Assert.IsNotNull(res);
        }
        [Test]
        public async Task DeleteCardTest()
        {
            var card = new Card()
            {
                Id = 7,
                CardNumber = "121212121212",
                CustomerID = 1,
                Pin = "0000",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
            };
            var addedCard = await _cardRepository.Add(card);
            var deleteCard = await _cardRepository.Delete(addedCard.Id);
            Assert.IsNotNull(deleteCard); 
        }
        [Test]
        public async Task GetAllCards()
        {
            var card = new Card()
            {
                Id = 10,
                CardNumber = "121212121212",
                CustomerID = 1,
                Pin = "0000",
                CreatedDate = DateTime.Now,
                ExpiryDate = DateTime.Now,
            };
            var addedCard = await _cardRepository.Add(card);
            var cards = await _cardRepository.GetAll();
            Assert.IsNotNull(cards);
        }
    }
}
