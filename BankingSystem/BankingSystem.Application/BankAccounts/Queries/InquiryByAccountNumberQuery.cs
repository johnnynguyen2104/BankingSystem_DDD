using BankingSystem.Application.BankAccounts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Queries
{
    public class InquiryByAccountNumberQuery : IRequest<InquiryViewModel>
    {
        public string AccountNumber { get; set; }

    }
}
