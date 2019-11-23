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
            CreateMap<AppUser, UserDto>();
        }
    }
}
