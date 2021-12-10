using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NRInvest.Domain.Commands.Login;
using System.Threading.Tasks;

namespace NRInvest.Api.Controllers
{
    [Route("login")]
    public sealed class LoginController : BaseController
    {
        public LoginController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(LoginCommand command)
        {
            return await SafeExecuteAsync(command);
        }
    }
}