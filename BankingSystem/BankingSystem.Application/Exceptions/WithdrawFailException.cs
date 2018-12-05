using BankingSystem.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.Exceptions
{
    public class WithdrawFailException : BankingException
    {
        public WithdrawFailException(string message) 
            : base(message)
        {

        }
    }
}
