using FluentValidation;
using MediatR;
using NRInvest.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NRInvest.Api.Pipelines
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorMessages = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(validatorResult => validatorResult.Errors)
                .Where(validatorFailure => validatorFailure != null)
                .Select(validatorFailure => validatorFailure.ErrorMessage);

            return errorMessages.Any() 
                ? throw new NRInvestValidationException(errorMessages) 
                : await next();
        }
    }
}