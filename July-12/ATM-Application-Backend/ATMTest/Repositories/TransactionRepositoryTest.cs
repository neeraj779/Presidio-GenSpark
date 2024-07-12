using ATMApplication.Exceptions;
using ATMApplication.Models;
using ATMApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATMApplication.Models.Transaction;
using static ATMApplication.Models.TransactionTypeEnum;

namespace ATMTest.Repositories
{
    public class TransactionRepositoryTest
    {
        ATMContext context;
        IRepository<Guid, Transaction> transactionRepository;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("TransactionDB");
            context = new ATMContext(optionsBuilder.Options);
            transactionRepository = new TransactionRepository(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AddTransactionSuccessTest()
        {
            // Action
            var result = await transactionRepository.Add(new Transaction
            { Id = Guid.NewGuid(), AccountId = 1, Time = DateTime.Now, Type = TransactionType.Deposit, Amount = 500 });

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetByTransactionIdSuccessTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();
            await transactionRepository.Add(new Transaction
            { Id = TransactionId, AccountId = 1, Time = DateTime.Now, Type = TransactionType.Deposit, Amount = 500 });

            // Action
            var result = transactionRepository.GetById(TransactionId);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetByTransactionIdFailTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();

            // Action
            var exception = Assert.ThrowsAsync<EntityNotFoundException>(() => transactionRepository.GetById(TransactionId));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Entity not found!"));
        }

        [Test]
        public async Task GetAllTransactionsSuccessTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();
            await transactionRepository.Add(new Transaction
            { Id = TransactionId, AccountId = 1, Time = DateTime.Now, Type = TransactionType.Deposit, Amount = 500 });

            // Action
            var result = await transactionRepository.GetAll();

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteTransactionByIdSuccessTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();
            await transactionRepository.Add(new Transaction
            { Id = TransactionId, AccountId = 1, Time = DateTime.Now, Type = TransactionType.Deposit, Amount = 500 });

            // Action
            var result = await transactionRepository.Delete(TransactionId);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DeleteTransactionByIdFailTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();

            // Action
            var exception = Assert.ThrowsAsync<EntityNotFoundException>(() => transactionRepository.Delete(TransactionId));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Entity not found!"));
        }

        [Test]
        public async Task UpdateTransactionFailTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();

            // Action
            var exception = Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => transactionRepository.Update(new Transaction
            { Id = TransactionId, AccountId = 1, Time = DateTime.Now, Type = TransactionType.Deposit, Amount = 500 }));

        }


        [Test]
        public async Task UpdateTransactionSuccessTest()
        {
            // Arrange
            Guid TransactionId = Guid.NewGuid();
            Transaction transaction1 = (new Transaction
            { Id = TransactionId, AccountId = 1, Time = DateTime.Now, Type = TransactionType.Deposit, Amount = 500 });
            await transactionRepository.Add(transaction1);
            Transaction transaction2 = await transactionRepository.GetById(TransactionId);
            transaction2.Amount = 1000;

            // Action
            var result = await transactionRepository.Update(transaction2);

            // Assert
            Assert.That(result.Amount, Is.EqualTo(1000));

        }
    }
}