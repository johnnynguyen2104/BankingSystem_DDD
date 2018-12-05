using BankingSystem.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankingSystem.Application.BankAccounts.Queries
{
    public class InquiryByAccountNumberQueryHandler : IRequestHandler<InquiryByAccountNumberQuery, decimal>
    {
        public readonly BankingSystemDbContext _bankingSystemDbContext;
        public InquiryByAccountNumberQueryHandler(BankingSystemDbContext bankingSystemDbContext)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
        }

        public Task<decimal> Handle(InquiryByAccountNumberQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
