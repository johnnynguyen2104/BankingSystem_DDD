using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Infrastructure.Exceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string mess) : base(mess)
        {

        }
    }
}
