using Auth.Common.Dtos.Identity;
using Auth.Domain;
using AutoMapper;

namespace Auth.Infrastructure.Mapping.Profiles
{
    /// <summary> Profile for <see cref="AppUser"/> </summary>
    public class UserProfile : Profile
    {
        /// <summary> Profile for <see cref="AppUser"/> </summary>
        public UserProfile()
        {
            CreateMap<AppUser, UserResponseDto>();

            CreateMap<AppUser, UserJwtResponseDto>()
                .ForMember(x => x.Token, a => a.Ignore())
                .ForMember(x => x.RefreshToken, a => a.Ignore())
                .IncludeBase<AppUser, UserResponseDto>();
        }
    }
}
