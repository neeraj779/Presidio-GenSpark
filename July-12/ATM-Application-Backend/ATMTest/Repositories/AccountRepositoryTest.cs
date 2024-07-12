using ATMApplication.Exceptions;
using ATMApplication.Models;
using ATMApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest.Repositories
{
    public class AccountRepositoryTest
    {
        DbContextOptionsBuilder optionsBuilder;
        IRepository<int , Account> _accountRepository;
        IRepository<int, Customer> _customerRepository;
        Customer c = null; 
            

        [SetUp]
        public async Task Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("AtmTest");
            var context = new ATMContext(optionsBuilder.Options);
            _accountRepository = new AccountRepository(context);
            _customerRepository = new CustomerRepository(context);  
            c = new Customer() { Id = 1, Name = "Test Customer", Age=21 ,Address="Test Address", Phone = "999999999", Gender="Male"};  
        }
        
        [Test]
        public async Task AddAccountTest()
        {
            await _customerRepository.Add(c);
            Account account = new Account() { AccountId = 1, AccountNo = "1234566443", Balance = 1000, CustomerID = 1 };
            var res = await _accountRepository.Add(account);
            Assert.That(res, Is.Not.Null);
        }
        
        [Test]
        public async Task GetAccountByIdTest()
        {
            Customer customer = new Customer() { Id = 2, Name = "Test Customer", Age = 21, Address = "Test Address", Phone = "999999999", Gender = "Male" };
            await _customerRepository.Add(customer);
            
            Account account2 = new Account() { AccountId = 2,AccountNo="1234566443" ,Balance = 1000, CustomerID = 2 };
            await _accountRepository.Add(account2);
            var res = await _accountRepository.GetById(account2.AccountId);
            Assert.That(res, Is.Not.Null);
        }
        
        [Test]
        public async Task GetAllAccountsTest()
        {
            var res = await _accountRepository.GetAll();
            Assert.That(res, Is.Not.Null);
        }
        
        [Test]
        public async Task UpdateAccountTest()
        {
            Account account = new Account() { AccountId = 4,AccountNo="1234566443" ,Balance = 1000, CustomerID = 1 };
            await _accountRepository.Add(account);
            account.Balance = 2000;
            var res = _accountRepository.Update(account);
            Assert.That(res, Is.Not.Null);
        }
        
        [Test]
        public async Task DeleteAccountTest()
        {
            Account account = new Account() { AccountId = 3,AccountNo="1234566443" ,Balance = 1000, CustomerID = 1 };
            await _accountRepository.Add(account);
            var res = _accountRepository.Delete(account.AccountId);
            Assert.That(res, Is.Not.Null);
        }
        [Test]
        public async Task GetByIdThrowsEntityNotFoundExceptionI()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _accountRepository.GetById(0) );
        }
    }
}
