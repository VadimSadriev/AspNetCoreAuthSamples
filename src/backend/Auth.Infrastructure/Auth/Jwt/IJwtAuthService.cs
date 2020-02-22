using Auth.Application.Dtos.Identity;
using Auth.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Auth.Jwt
{
    /// <summary> Service for json web token authentication </summary>
    public interface IJwtAuthService
    {
        /// <summary> Returns new jwt authentication token for user</summary>
        Task<JwtTokenDto> GetToken(AppUser user);

        /// <summary>Returns claims principle from jwt token</summary>
        public ClaimsPrincipal GetPrincipleFromToken(string token);
    }
}