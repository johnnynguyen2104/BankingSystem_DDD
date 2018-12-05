using BankingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Persistence.Interfaces
{
    public interface IAccountRepository
    {
        decimal GetCurrentBalanceByAccountId(BankAccount account);

        BankAccount GetAccountByAccountNumber(string accountNumber);
    }
}
