using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Models;

namespace NRInvest.Infrastructure.MongoDB.Repositories
{
    public sealed class AccountRepository : BaseMongoRepository<Account>, IAccountRepository
    {
        public AccountRepository(MongoSettings mongoSettings) : base(mongoSettings)
        {
        }
    }
}