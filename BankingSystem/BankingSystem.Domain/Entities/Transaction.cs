using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        
        public ActionCode Action { get; set; }

        public decimal OldAmount { get; set; }

        public decimal NewAmount { get; set; }

        public string Details { get; set; }

        public int AccountId { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
