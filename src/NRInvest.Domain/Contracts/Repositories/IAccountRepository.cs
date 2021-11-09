using NRInvest.Domain.Entities;
using System.Threading.Tasks;

namespace NRInvest.Domain.Contracts.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> AddAsync(Account account);
    }
}