using FluentValidation;

namespace NRInvest.Domain.Commands.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(account => account.Email).NotEmpty();
            RuleFor(account => account.Password).NotEmpty();
        }
    }
}