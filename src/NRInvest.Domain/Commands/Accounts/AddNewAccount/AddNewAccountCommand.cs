using MediatR;

namespace NRInvest.Domain.Commands.Accounts.AddNewAccount
{
    public sealed class AddNewAccountCommand : IRequest<object>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}