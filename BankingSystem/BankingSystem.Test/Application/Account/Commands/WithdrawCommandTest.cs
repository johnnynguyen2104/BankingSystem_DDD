using BankingSystem.Application.BankAccounts.Commands;
using BankingSystem.Application.BankAccounts.Validations;
using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Common;
using BankingSystem.Domain.Entities;
using BankingSystem.Infrastructure;
using BankingSystem.Persistence;
using BankingSystem.Persistence.Interfaces;
using BankingSystem.Persistence.Repositories;
using BankingSystem.Test.Infrastructure;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankingSystem.Test.Application.Account.Commands
{
    [TestFixture]
    public class WithdrawCommandTest
    {

        WithdrawCommandValidation validation = new WithdrawCommandValidation();
        BankingSystemDbContext context;
        WithdrawCommandHandler handler;
        IDateTime dateTime = new FakeMachineDateTime();
        ICurrencyService currencyService = new CurrencyService();
        IAccountRepository _accountRepository;

        [SetUp]
        public void Setup()
        {
            context = BankingContext.Create();
            handler = new WithdrawCommandHandler(currencyService, context, dateTime);
            _accountRepository = new AccountRepository(context, dateTime);
        }

        [Test]
        public void Withdraw_GivenUnSupportCurrency_ShouldThrowBusinessErrorException()
        {
            var command = new WithdrawCommand() { AccountNumber = "1", Amount = 3, Currency = "VND" };

            var result = Assert.ThrowsAsync<WithdrawFailException>(() => handler.Handle(command, CancellationToken.None));

            result.ShouldNotBeNull();
            result.Message.Contains("Invalid Currency VND.");
        }


        [Test]
        public void Withdraw_GivenNegativeExchangedAmount_ShouldThrowBusinessErrorException()
        {
            var command = new WithdrawCommand() { AccountNumber = "1", Amount = -3, Currency = "USD" };

            var result = Assert.ThrowsAsync<WithdrawFailException>(() => handler.Handle(command, CancellationToken.None));

            result.ShouldNotBeNull();
            result.Message.Contains("Invalid actual amount after exchanged.");
        }

        [Test]
        public void Withdraw_GivenCorrectRequest_WithSameCurrency_NotEnoughBalance_ShouldThrowBusinessException()
        {
            var command = new WithdrawCommand() { AccountNumber = "1", Amount = 3000, Currency = "USD" };

            var result = Assert.ThrowsAsync<WithdrawFailException>(() => handler.Handle(command, CancellationToken.None));

            result.ShouldNotBeNull();
            result.Message.Contains("The current balance not enough to withdraw.");
        }

        [TestCaseSource("CorrectWithdrawDifferentCurrency")]
        public async Task Withdraw_GivenCorrectRequest_WithDifferenntCurrency_ShouldWithdrawSuccessfulWithCorrectAmount(WithdrawCommand command, decimal expectedAmount, decimal transactionAmount)
        {
            await handler.Handle(command, CancellationToken.None);

            var withdrawedAccount = context.BankAccounts.First(a => a.AccountNumber == command.AccountNumber);

            var currentBalance = _accountRepository.GetCurrentBalanceByAccountId(withdrawedAccount);
            var withdrawTransaction = context.Transactions.FirstOrDefault(a => a.AccountId == withdrawedAccount.Id 
            && a.TransactionDatetime == dateTime.Now
            && a.Action == ActionCode.Withdraw);

            currentBalance.ShouldBe(expectedAmount);
            withdrawTransaction.ShouldNotBeNull();
            withdrawTransaction.Amount.ShouldBe(transactionAmount);
            withdrawedAccount.LastActivityDate.ShouldBe(dateTime.Now);
        }

        [Test]
        public async Task Withdraw_GivenCorrectRequest_WithSameCurrency_ShouldWithdrawSuccessfulWithCorrectAmount()
        {
            WithdrawCommand command = new WithdrawCommand() {  AccountNumber = "1", Amount = 30, Currency = "THB"};
            await handler.Handle(command, CancellationToken.None);

            var withdrawedAccount = context.BankAccounts.First(a => a.AccountNumber == command.AccountNumber);

            var currentBalance = _accountRepository.GetCurrentBalanceByAccountId(withdrawedAccount);
            var withdrawTransaction = context.Transactions.FirstOrDefault(a => a.AccountId == withdrawedAccount.Id
            && a.TransactionDatetime == dateTime.Now
            && a.Action == ActionCode.Withdraw);


            currentBalance.ShouldBe(70);
            withdrawTransaction.ShouldNotBeNull();
            withdrawTransaction.Amount.ShouldBe(30);
            withdrawedAccount.LastActivityDate.ShouldBe(dateTime.Now);
        }

        [TestCaseSource("CorrectWithdraw_NotEnoughBalance")]
        public void Withdraw_GivenCorrectRequest_WithDifferenntCurrency_NotEnoughBalance_ShouldThrowBusinessException(WithdrawCommand command)
        {
            var result = Assert.ThrowsAsync<WithdrawFailException>(() => handler.Handle(command, CancellationToken.None));

            result.ShouldNotBeNull();
            result.Message.Contains("The current balance not enough to withdraw.");
        }

        #region test data
        private static object[] CorrectWithdrawDifferentCurrency = new object[] {
            new object[] { new WithdrawCommand() { AccountNumber = "1", Amount = 1, Currency= "USD"  }, 67m, 33m  }
            ,new object[] { new WithdrawCommand() { AccountNumber = "1", Amount = 1, Currency= "EUR"  }, 60m, 40m  }
        };

        private static object[] CorrectWithdraw_NotEnoughBalance = new object[] {
            new object[] { new WithdrawCommand() { AccountNumber = "1", Amount = 1000, Currency= "USD"  }}
            ,new object[] { new WithdrawCommand() { AccountNumber = "2", Amount = 1000, Currency= "EUR"  }}
        };
        #endregion
    }
}
