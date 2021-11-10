using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
using NRInvest.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NRInvest.Api.Controllers
{
    [Route("accounts")]
    public sealed class AccountController : BaseController
    {
        public AccountController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(Account), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(AddNewAccountCommand command)
        {
            return await SafeExecuteAsync(command);
        }
    }
}