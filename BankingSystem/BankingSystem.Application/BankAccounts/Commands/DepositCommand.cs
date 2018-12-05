using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Commands
{
    public class DepositCommand : IRequest
    {
        public string AccountNumber { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }
    }
}
