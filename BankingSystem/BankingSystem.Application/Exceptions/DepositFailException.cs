using BankingSystem.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Exceptions
{
    public class DepositFailException : BankingException
    {
        public DepositFailException(string message) : base(message)
        {
        }
    }
}
