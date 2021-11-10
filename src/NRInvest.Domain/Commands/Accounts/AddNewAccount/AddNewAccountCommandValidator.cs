using FluentValidation;

namespace NRInvest.Domain.Commands.Accounts.AddNewAccount
{
    public sealed class AddNewAccountCommandValidator : AbstractValidator<AddNewAccountCommand>
    {
        public AddNewAccountCommandValidator()
        {
            RuleFor(account => account.UserName).NotEmpty();
            RuleFor(account => account.Email).NotEmpty();
            RuleFor(account => account.Password).NotEmpty();
        }
    }
}