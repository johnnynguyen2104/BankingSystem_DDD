using BankingSystem.Application.BankAccounts.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Validations
{
    public class DepositCommandValidation: AbstractValidator<DepositCommand>
    {
        public DepositCommandValidation()
        {
            RuleFor(a => a.AccountNumber)
               .MaximumLength(30)
               .NotEmpty();

            RuleFor(a => a.Currency)
              .MaximumLength(5)
              .NotEmpty();

            RuleFor(a => a.Amount)
                .GreaterThan(0);
        }
    }
}
