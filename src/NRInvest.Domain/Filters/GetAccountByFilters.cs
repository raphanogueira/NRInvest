using MongoDB.Driver;
using NRInvest.Domain.Contracts;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Extensions;

namespace NRInvest.Domain.Filters
{
    public sealed class GetAccountByFilters : IMongoFilter<Account>
    {
        private readonly string _email;
        private readonly string _password;

        public GetAccountByFilters(string email, string password)
        {
            _email = email;
            _password = password.Encrypt();
        }

        public FilterDefinition<Account> Build()
        {
            return Builders<Account>.Filter.Eq(account => account.Email, _email) &
                Builders<Account>.Filter.Eq(account => account.Password, _password);
        }
    }
}