namespace NRInvest.Domain.Models
{
    public sealed class RedisSettings : Settings
    {
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }
    }
}