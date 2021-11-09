﻿using MongoDB.Driver;
using NRInvest.Domain.Models;
using System.Threading.Tasks;

namespace NRInvest.Infrastructure.MongoDB.Repositories
{
    public class BaseMongoRepository<T>
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
    }
}