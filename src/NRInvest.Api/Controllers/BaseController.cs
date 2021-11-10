using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NRInvest.Domain.Commands;
using NRInvest.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace NRInvest.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IServiceProvider ServiceProvider;

        protected BaseController(
            IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected async Task<IActionResult> SafeExecuteAsync(BaseCommand command)
        {
            try
            {
                using var scope = ServiceProvider.CreateScope();

                var mediator = ServiceProvider.GetService<IMediator>();

                return Ok(await mediator.Send(command));
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