using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Auth.Infrastructure.Auth.Jwt
{
    /// <summary> The authorization policy for token-based authentication </summary>
    public class AuthorizeJwtAttribute : AuthorizeAttribute
    {
        /// <summary> The authorization policy for token-based authentication </summary>
        public AuthorizeJwtAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
