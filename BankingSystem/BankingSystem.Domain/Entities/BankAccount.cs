using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public class BankAccount
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Amount { get; set; }

        public bool IsActive { get; set; }

        public byte[] RowVersion { get; set; }

        public string Currency { get; set; }

        public virtual ICollection<Transaction> Histories { get; set; }
    }
}
