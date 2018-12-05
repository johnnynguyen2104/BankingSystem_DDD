using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Queries
{
    public class InquiryByAccountNumberQuery : IRequest<decimal>
    {
        public string AccountNumber { get; set; }

    }
}
