using AutoMapper;
using MediatR;
using NRInvest.Domain.Contracts.Repositories;
using NRInvest.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NRInvest.Domain.Commands.Accounts.AddNewAccount
{
    public sealed class AddNewAccountCommandHandler : IRequestHandler<AddNewAccountCommand, object>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AddNewAccountCommandHandler(IAccountRepository accountRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(AddNewAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);

            return await _accountRepository.AddAsync(account);
        }
    }
}