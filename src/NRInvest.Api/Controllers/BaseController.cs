using MediatR;
using Microsoft.AspNetCore.Mvc;
using NRInvest.Api.Attributes;
using NRInvest.Domain.Commands;
using NRInvest.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace NRInvest.Api.Controllers
{
    [NRInvestAuthorize]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator Mediator;

        protected BaseController(
            IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async Task<IActionResult> SafeExecuteAsync(BaseCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return ex switch
                {
                    NRInvestValidationException => BadRequest(ex.Message),
                    _ => Problem()
                };
            }
        }
    }
}