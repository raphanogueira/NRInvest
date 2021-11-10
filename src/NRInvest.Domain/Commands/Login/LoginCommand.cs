namespace NRInvest.Domain.Commands.Login
{
    public sealed class LoginCommand : BaseCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}