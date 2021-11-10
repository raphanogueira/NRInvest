using AutoMapper;
using NRInvest.Domain.Commands.Accounts.AddNewAccount;
using NRInvest.Domain.Entities;
using NRInvest.Domain.Extensions;

namespace NRInvest.Domain.Profiles
{
    public sealed class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AddNewAccountCommand, Account>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.Encrypt()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture));
        }
    }
}