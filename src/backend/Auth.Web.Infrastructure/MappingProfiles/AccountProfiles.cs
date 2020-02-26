using Auth.Application.Dtos.Identity;
using Auth.Contracts.AccountContracts;
using Auth.Domain;
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
            CreateMap<RefreshJwtTokenContract, RefreshJwtTokenDto>();
        }
    }
}
