using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BankingSystem.Application.BankAccounts.Commands;
using BankingSystem.Application.BankAccounts.Models;
using BankingSystem.Application.BankAccounts.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankingSystem.WebApi.Controllers
{

    public class AccountController : BaseController
    {

        protected readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [Route("/api/account/balance/{AccountNumber}")]
        [ProducesResponseType(typeof(IEnumerable<InquiryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Inquiry(string AccountNumber)
        {
            InquiryByAccountNumberQuery query = new InquiryByAccountNumberQuery() { AccountNumber = AccountNumber };
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("/api/account/withdraw")]
        [ProducesResponseType(typeof(IEnumerable<InquiryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawCommand command)
        {
            await Mediator.Send(command);
            var query = new InquiryByAccountNumberQuery() { AccountNumber = command.AccountNumber };
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("/api/account/deposit")]
        [ProducesResponseType(typeof(IEnumerable<InquiryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Deposit([FromBody] DepositCommand command)
        {
            await Mediator.Send(command);
            var query = new InquiryByAccountNumberQuery() { AccountNumber = command.AccountNumber };
            return Ok(await Mediator.Send(query));
        }
    }
}
