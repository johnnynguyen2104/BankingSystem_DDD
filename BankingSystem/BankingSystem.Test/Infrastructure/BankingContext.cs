using BankingSystem.Domain.Entities;
using BankingSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Test.Infrastructure
{
    public class BankingContext
    {
        public static BankingSystemDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BankingSystemDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BankingSystemDbContext(options);

            context.Database.EnsureCreated();


            int a1 = 1,
               a2 = 2,
               a3 = 3;

            context.BankAccounts.AddRange(new[] {
                new BankAccount() { Id = a1, AccountNumber = "1", IsActive = true, Currency = "THB" },
                new BankAccount() { Id = a2, AccountNumber = "2", IsActive = true, Currency = "THB" },
                new BankAccount() { Id = a3, AccountNumber = "3", IsActive = true, Currency = "THB" }
            });

            context.Transactions.AddRange(
                new AccountTransaction() { AccountId = a1, Id = 10001, Action = ActionCode.Deposit, Amount = 100, Note = "This is the initial deposit.", TransactionDatetime = new DateTime(2018, 12, 5, 22, 30, 0, 0) },
                new AccountTransaction() { AccountId = a2, Id = 10002, Action = ActionCode.Deposit, Amount = 200, Note = "This is the initial deposit.", TransactionDatetime = new DateTime(2018, 12, 5, 22, 30, 0, 0) },
                new AccountTransaction() { AccountId = a3, Id = 10003, Action = ActionCode.Deposit, Amount = 300, Note = "This is the initial deposit.", TransactionDatetime = new DateTime(2018, 12, 5, 22, 30, 0, 0) }
               );

            context.Statements.AddRange(
                new AccountStatement() { AccountId = a1, ClosingBalance = 0, Id = 1, StatementDetails = "This statement on Dec, 2018" },
                new AccountStatement() { AccountId = a2, ClosingBalance = 0, Id = 2, StatementDetails = "This statement on Dec, 2018" },
                new AccountStatement() { AccountId = a3, ClosingBalance = 0, Id = 3, StatementDetails = "This statement on Dec, 2018" }
                );

            context.SaveChanges();

            return context;
        }
    }
}
