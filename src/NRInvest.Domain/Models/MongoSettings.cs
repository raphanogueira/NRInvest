namespace NRInvest.Domain.Models
{
    public sealed class MongoSettings : Settings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}