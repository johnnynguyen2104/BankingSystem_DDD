using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Domain.Entities
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; set; }
    }
}
