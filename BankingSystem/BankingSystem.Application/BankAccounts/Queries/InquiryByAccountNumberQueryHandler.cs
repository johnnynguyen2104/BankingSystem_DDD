using BankingSystem.Application.BankAccounts.Exceptions;
using BankingSystem.Application.BankAccounts.Models;
using BankingSystem.Application.Interfaces;
using BankingSystem.Common;
using BankingSystem.Domain.Entities;
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
        private readonly IDateTime _machineDateTime;

        public InquiryByAccountNumberQueryHandler(BankingSystemDbContext bankingSystemDbContext
            , IDateTime machineDateTime)
        {
            _bankingSystemDbContext = bankingSystemDbContext;
            _machineDateTime = machineDateTime;
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

                var currentBalance = _accountRepository.GetCurrentBalanceByAccountId(account);

                _bankingSystemDbContext.Transactions.Add(new AccountTransaction()
                {
                    AccountId = account.Id,
                    Amount = currentBalance,
                    Action = ActionCode.Inquiry,
                    TransactionDatetime = _machineDateTime.Now
                });

                if (_bankingSystemDbContext.SaveChanges() <= 0)
                {
                    throw new InquiryFailException($"Inquiry fail with account number - {request.AccountNumber}.");
                }

                return new InquiryViewModel()
                {
                    AccountNumber = account.AccountNumber,
                    Currency = account.Currency,
                    Balance = currentBalance
                };

            });

        }
    }
}
