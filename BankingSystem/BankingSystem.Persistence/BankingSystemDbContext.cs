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

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<AccountTransaction> Transactions { get; set; }

        public DbSet<AccountStatement> Statements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed(modelBuilder);
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new AccountStatementConfiguration());
        }


        private void Seed(ModelBuilder modelBuilder)
        {
            int a1 = 1,
                a2 = 2,
                a3 = 3;

            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount() { Id = a1, AccountNumber = "4111111111111111", IsActive = true, Currency = "THB"  },
                new BankAccount() { Id = a2, AccountNumber = "4222222222222222", IsActive = true, Currency = "THB" },
                new BankAccount() { Id = a3, AccountNumber = "4333333333333333", IsActive = true, Currency = "THB" }
                );

            modelBuilder.Entity<AccountTransaction>().HasData(
                new AccountTransaction() { AccountId = a1, Id= 1, Action = ActionCode.Deposit, Amount = 100, Note = "This is the initial deposit."  },
                new AccountTransaction() { AccountId = a2, Id= 2, Action = ActionCode.Deposit, Amount = 200, Note = "This is the initial deposit."  },
                new AccountTransaction() { AccountId = a3, Id= 3, Action = ActionCode.Deposit, Amount = 300, Note = "This is the initial deposit."  }
               );

            modelBuilder.Entity<AccountStatement>().HasData(
                new AccountStatement() { AccountId = a1, ClosingBalance = 0, Id = 1, StatementDetails = "This statement on Dec, 2018" },
                new AccountStatement() { AccountId = a2, ClosingBalance = 0, Id = 2, StatementDetails = "This statement on Dec, 2018" },
                new AccountStatement() { AccountId = a3, ClosingBalance = 0, Id = 3, StatementDetails = "This statement on Dec, 2018" }
                );
        }
    }
}
