using Microsoft.AspNetCore.Mvc;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
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
        public async Task<IActionResult> PostAsync(AddNewAccountCommand command)
        {
            return await SafeExecuteAsync(command);
        }
    }
}