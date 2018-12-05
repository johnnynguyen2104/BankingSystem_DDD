using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Commands
{
    public class WithdrawCommand : IRequest
    {
        public string AccountNumber { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
