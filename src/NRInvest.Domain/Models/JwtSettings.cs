namespace NRInvest.Domain.Models
{
    public sealed class JwtSettings : Settings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}