using BankingSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
