using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Infrastructure.Models
{
    public class CurrencyInfo
    {
        public string BaseCurrency { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }
    }
}
