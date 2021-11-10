using MediatR;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace NRInvest.Domain.Commands.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, object>
    {
        private readonly IBaseMongoRepository<Account> _accountRepository;

        public LoginCommandHandler(IBaseMongoRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<object> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.GetAsync(new GetAccountByFilters(request.Email, request.Password));

            if (user is null)
                return null;

            return user;
        }
    }
}