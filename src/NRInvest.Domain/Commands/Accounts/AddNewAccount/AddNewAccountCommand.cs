namespace NRInvest.Domain.Commands.Accounts.AddNewAccount
{
    public sealed class AddNewAccountCommand : BaseCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}