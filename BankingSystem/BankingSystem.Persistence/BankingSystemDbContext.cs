﻿using BankingSystem.Domain.Entities;
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

        DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
