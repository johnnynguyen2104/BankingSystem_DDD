using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public class AccountTransaction : AggregateRoot
    {
        
        public ActionCode Action { get; set; }

        public decimal Amount { get; set; }

        public string Note { get; set; }

        public int AccountId { get; set; }

        public DateTime TransactionDatetime { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
