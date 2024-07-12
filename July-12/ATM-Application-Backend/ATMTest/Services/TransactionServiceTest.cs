using ATMApplication.Models;
using ATMApplication.Repositories;
using ATMApplication.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest.Services
{
    public class TransactionServiceTest
    {
        ATMContext context;
        ITransactionService transactionService;
        IRepository<Guid, Transaction> transactionRepo;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("AuthenticationDB");
            context = new ATMContext(optionsBuilder.Options);
            transactionRepo = new TransactionRepository(context);
            transactionService = new TransactionService(transactionRepo, null, null);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task GetAllTransactionsSuccessTest()
        {

        }
    }
}
