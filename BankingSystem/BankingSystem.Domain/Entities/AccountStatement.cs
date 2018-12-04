using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public class AccountStatement : AggregateRoot
    {
        public Guid AccountId { get; set; }

        public DateTime StatementDate { get; set; }

        public string StatementDetails { get; set; }

        public decimal ClosingBalance { get; set; }

        public virtual BankAccount Account { get; set; }
    }
}
