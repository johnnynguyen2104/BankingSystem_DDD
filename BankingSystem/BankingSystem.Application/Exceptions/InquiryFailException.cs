using BankingSystem.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Exceptions
{
    public class InquiryFailException: BankingException
    {
        public InquiryFailException(string mess) : base(mess)
        {

        }
    }
}
