using NRInvest.Domain.Entities;

namespace NRInvest.Domain.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        string GenerateToken(Account account);
    }
}
