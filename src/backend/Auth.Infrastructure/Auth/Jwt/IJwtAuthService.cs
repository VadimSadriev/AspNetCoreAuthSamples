using Auth.Domain;

namespace Auth.Infrastructure.Auth.Jwt
{
    /// <summary> Service for json web token authentication </summary>
    public interface IJwtAuthService
    {
        /// <summary> Returns new jwt authentication token for user</summary>
        string GetToken(AppUser user);
    }
}
