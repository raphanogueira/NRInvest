using MongoDB.Driver;

namespace NRInvest.Domain.Contracts
{
    public interface IMongoFilter<T>
    {
        public FilterDefinition<T> Build();
    }
}