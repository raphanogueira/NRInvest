using NRInvest.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NRInvest.Domain.Contracts.Repositories
{
    public interface IBaseMongoRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(IMongoFilter<T> filters);
        Task<T> GetByIdAsync(Guid id);
    }
}
