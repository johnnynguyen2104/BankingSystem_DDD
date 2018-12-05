using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Common.Exceptions
{
    public class BankingException : Exception
    {
       public ErrorDetails ErrorDetails { get; set; } 

        public BankingException(string message) : base(message)
        {
            ErrorDetails = new ErrorDetails(message);
        }
    }
}
