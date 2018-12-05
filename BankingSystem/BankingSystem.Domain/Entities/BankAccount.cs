using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public class BankAccount : AggregateRoot
    { 
        public string AccountNumber { get; set; }

        public bool IsActive { get; set; }

        public byte[] RowVersion { get; set; }

        public string Currency { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastActivityDate { get; set; }

        public virtual ICollection<AccountTransaction> Transactions { get; set; }

        public virtual ICollection<AccountStatement> Statements { get; set; }
    }
}
