using MongoDB.Driver;
using NRInvest.Domain.Contracts;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Models;
using System.Threading.Tasks;

namespace NRInvest.Infrastructure.MongoDB.Repositories
{
    public class BaseMongoRepository<T> : IBaseMongoRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> Collection;

        public BaseMongoRepository(MongoSettings mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.ConnectionString);
            var database = mongoClient.GetDatabase(mongoSettings.DatabaseName);

            Collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> AddAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<T> GetAsync(IMongoFilter<T> filters)
        {
            return await Collection.Find(filters.Build()).FirstOrDefaultAsync();
        }
    }
}