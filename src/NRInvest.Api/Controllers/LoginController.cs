using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NRInvest.Domain.Commands.Login;
using System;
using System.Threading.Tasks;

namespace NRInvest.Api.Controllers
{
    [Route("login")]
    public sealed class LoginController : BaseController
    {
        public LoginController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(LoginCommand command)
        {
            return await SafeExecuteAsync(command);
        }
    }
}