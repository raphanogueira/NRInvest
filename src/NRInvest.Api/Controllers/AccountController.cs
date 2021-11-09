using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
using System.Threading.Tasks;

namespace NRInvest.Api.Controllers
{
    [Route("accounts")]
    public sealed class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddNewAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}