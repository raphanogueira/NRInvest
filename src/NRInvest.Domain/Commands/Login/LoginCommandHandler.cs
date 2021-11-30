using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using NRInvest.Domain.Contracts.Authentication;
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
        private readonly IAuthenticationService _authenticationService;
        private readonly IDistributedCache _distributedCache;

        public LoginCommandHandler(IBaseMongoRepository<Account> accountRepository,
            IAuthenticationService authenticationService,
            IDistributedCache distributedCache)
        {
            _accountRepository = accountRepository;
            _authenticationService = authenticationService;
            _distributedCache = distributedCache;
        }

        public async Task<object> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAsync(new GetAccountByFilters(request.Email, request.Password));

            var token = _authenticationService.GenerateToken(account);

            return token;
        }
    }
}