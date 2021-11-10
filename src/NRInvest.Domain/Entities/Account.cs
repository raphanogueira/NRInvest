using System.Text.Json.Serialization;

namespace NRInvest.Domain.Entities
{
    public sealed class Account : Entity
    {
        public string UserName { get; private set; }
        [JsonIgnore]
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Picture { get; private set; }
    }
}