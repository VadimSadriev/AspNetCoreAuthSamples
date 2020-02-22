using Auth.Application.Dtos.Identity;
using Auth.Domain;
using Auth.Web.Contracts.AccountContracts;
using AutoMapper;

namespace Auth.Web.Infrastructure.MappingProfiles
{
    public class AccountProfiles : Profile
    {
        public AccountProfiles()
        {
            CreateMap<AppUser, UserResponseContract>();
            CreateMap<UserCreateContract, UserCreateDto>();
            CreateMap<UserSigninContract, UserSigninDto>();
            CreateMap<UserJwtResponseDto, UserJwtResponseContract>();
        }
    }
}
