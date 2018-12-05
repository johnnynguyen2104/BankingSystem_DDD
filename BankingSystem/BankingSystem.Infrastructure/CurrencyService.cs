using BankingSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure
{
    public class CurrencyService : ICurrencyService
    {
        public Task<decimal> GetRates(string baseCurrency, string exchangeCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
