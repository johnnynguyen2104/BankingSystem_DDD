using BankingSystem.Domain.Entities;
using BankingSystem.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace BankingSystem.Persistence
{
    public class BankingSystemDbContext : DbContext
    {
        public BankingSystemDbContext(DbContextOptions<BankingSystemDbContext> options)
            : base(options)
        {
        }

        DbSet<BankAccount> BankAccounts { get; set; }

        DbSet<AccountTransaction> Transactions { get; set; }

        DbSet<AccountStatement> Statements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed(modelBuilder);

            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new AccountStatementConfiguration());
        }


        private void Seed(ModelBuilder modelBuilder)
        {
            Guid a1 = Guid.NewGuid(),
                a2 = Guid.NewGuid(),
                a3 = Guid.NewGuid();

            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount() { Id = a1, AccountNumber = "4111111111111111", IsActive = true, Currency = "THB"  },
                new BankAccount() { Id = a2, AccountNumber = "4222222222222222", IsActive = true, Currency = "USD" },
                new BankAccount() { Id = a3, AccountNumber = "4333333333333333", IsActive = true, Currency = "EUR" }
                );

            modelBuilder.Entity<AccountTransaction>().HasData(
                new AccountTransaction() { AccountId = a1, Id= Guid.NewGuid(), Action = ActionCode.Deposit, Amount = 100, Note = "This is the initial deposit."  },
                new AccountTransaction() { AccountId = a2, Id= Guid.NewGuid(), Action = ActionCode.Deposit, Amount = 200, Note = "This is the initial deposit."  },
                new AccountTransaction() { AccountId = a3, Id= Guid.NewGuid(), Action = ActionCode.Deposit, Amount = 300, Note = "This is the initial deposit."  }
               );

            modelBuilder.Entity<AccountStatement>().HasData(
                new AccountStatement() { AccountId = a1, ClosingBalance = 0, Id = Guid.NewGuid(), StatementDetails = "This statement on Dec, 2018" },
                new AccountStatement() { AccountId = a2, ClosingBalance = 0, Id = Guid.NewGuid(), StatementDetails = "This statement on Dec, 2018" },
                new AccountStatement() { AccountId = a3, ClosingBalance = 0, Id = Guid.NewGuid(), StatementDetails = "This statement on Dec, 2018" }
                );
        }
    }
}
