using BankingSystem.Application.BankAccounts.Exceptions;
using BankingSystem.Application.BankAccounts.Models;
using BankingSystem.Application.Interfaces;
using BankingSystem.Common;
using BankingSystem.Persistence;
using BankingSystem.Persistence.Interfaces;
using BankingSystem.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankingSystem.Application.BankAccounts.Queries
{
    public class InquiryByAccountNumberQueryHandler : IRequestHandler<InquiryByAccountNumberQuery, InquiryViewModel>
    {

        private readonly BankingSystemDbContext _bankingSystemDbContext;
        private readonly IAccountRepository _accountRepository;

        public InquiryByAccountNumberQueryHandler(BankingSystemDbContext bankingSystemDbContext
            , IDateTime machineDateTime)
        {
            _bankingSystemDbContext = bankingSystemDbContext;

            _accountRepository = new AccountRepository(_bankingSystemDbContext, machineDateTime);
        }

        public Task<InquiryViewModel> Handle(InquiryByAccountNumberQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {


                var account = _accountRepository.GetAccountByAccountNumber(request.AccountNumber);

                if (account == null)
                {
                    throw new InquiryFailException($"Account Number - {request.AccountNumber} could not be found.");
                }

                return new InquiryViewModel()
                {
                    AccountNumber = account.AccountNumber,
                    Currency = account.Currency,
                    Balance = _accountRepository.GetCurrentBalanceByAccountId(account)
                };

            });

        }
    }
}
