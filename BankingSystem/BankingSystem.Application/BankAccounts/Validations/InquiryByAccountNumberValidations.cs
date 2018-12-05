using BankingSystem.Application.BankAccounts.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Application.BankAccounts.Validations
{
    public class InquiryByAccountNumberValidations : AbstractValidator<InquiryByAccountNumberQuery>
    {
        public InquiryByAccountNumberValidations()
        {
            RuleFor(a => a.AccountNumber)
                .MaximumLength(30)
                .NotEmpty();
        }
    }
}
