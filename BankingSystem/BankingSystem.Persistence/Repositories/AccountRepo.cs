using BankingSystem.Common;
using BankingSystem.Domain.Entities;
using BankingSystem.Persistence.Exceptions;
using BankingSystem.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingSystem.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingSystemDbContext _bankingSystemDbContext;
        private readonly IDateTime _machineDateTime;

        public AccountRepository(BankingSystemDbContext bankingSystemDbContext
            , IDateTime machineDateTime)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
            _machineDateTime = machineDateTime;
        }

        public BankAccount GetAccountByAccountNumber(string accountNumber)
        {
            if (!accountNumber.IsValid())
            {
                throw new ArgumentNullException("accountNumber was null or Empty.");
            }

            var result = _bankingSystemDbContext.BankAccounts.FirstOrDefault(a => a.IsActive && a.AccountNumber == accountNumber);

            if (result == null)
            {
                throw new DomainEntityNotFoundException($"No Account was found by account numbe - {accountNumber}");
            }

            return result;
        }

        public decimal GetCurrentBalanceByAccountId(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account arguement was null.");
            }

            var latestStatement = _bankingSystemDbContext.Statements.FirstOrDefault(a => a.AccountId == account.Id);

            if (latestStatement == null)
            {
                throw new DomainEntityNotFoundException($"Latest statement was not found, accountNumber = {account.AccountNumber}.");
                                                                
            }

            var transactionsFromLatestStatement = _bankingSystemDbContext.Transactions
                                                                .Where(a => a.TransactionDatetime >= latestStatement.StatementDateTime && a.AccountId == account.Id)
                                                                .Select(a => new { Action = a.Action, Amount = a.Amount });

            var withdrawAmountFromLatestStatement = transactionsFromLatestStatement
                                                                .Where(a => a.Action == ActionCode.Withdraw)
                                                                .Sum(a => a.Amount);

            var depositAmountFromLatestStatement = transactionsFromLatestStatement
                                                    .Where(a => a.Action == ActionCode.Deposit)
                                                    .Sum(a => a.Amount);

            var currentBalance = (latestStatement.ClosingBalance + depositAmountFromLatestStatement) 
                                - withdrawAmountFromLatestStatement;


            return currentBalance;
        }
    }
}
