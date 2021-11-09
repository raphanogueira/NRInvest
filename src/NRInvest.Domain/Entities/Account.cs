namespace NRInvest.Domain.Entities
{
    public sealed class Account : Entity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Picture { get; private set; }
    }
}