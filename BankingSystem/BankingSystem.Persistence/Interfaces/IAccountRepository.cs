using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Persistence.Interfaces
{
    public interface IAccountRepository
    {
        decimal GetCurrentBalanceByAccountId(Guid accountId);
    }
}
