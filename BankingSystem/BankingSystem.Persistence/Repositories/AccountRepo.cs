using BankingSystem.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {


        public decimal GetCurrentBalanceByAccountId(Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}
