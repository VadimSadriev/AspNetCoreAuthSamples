using Auth.Application.Dtos.Identity;
using Auth.Domain;
using System.Threading.Tasks;

namespace Auth.Application.Common.Interfaces.Identity
{
    /// <summary> Provides functionality for user management </summary>
    public interface IUserManager
    {
        /// <summary> Creates new user  </summary>
        Task<AppUser> CreateUser(UserCreateDto userDto);

        /// <summary> Checks user existens and return jwt auth token </summary>
        Task<UserJwtResponseDto> SigninWithJwt(UserSigninDto userSigninDto);

        /// <summary> Refreshes jwt token</summary>
        Task<UserJwtResponseDto> RefreshJwtToken(RefreshJwtTokenDto refreshJwtTokenDto);

        /// <summary> Returns user by id </summary>
        Task<AppUser> GetById(string id);
    }
}