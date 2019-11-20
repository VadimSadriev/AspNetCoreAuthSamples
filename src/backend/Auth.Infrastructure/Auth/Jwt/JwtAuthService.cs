using Auth.Common.Time;
using Auth.Infrastructure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Infrastructure.Auth.Jwt
{
    /// <summary> Service for json web token authentication </summary>
    public class JwtAuthService : IJwtAuthService
    {
        /// <summary> options for token generation </summary>
        private readonly JwtOptions _jwtOptions;

        /// <summary> Service for machine date time </summary>
        private readonly IDateTime _timeService;

        /// <summary> Service for json web token authentication </summary>
        public JwtAuthService(IOptions<JwtOptions> jwtOptions, IDateTime timeService)
        {
            _jwtOptions = jwtOptions.Value;
            _timeService = timeService;
        }

        /// <summary> Returns new jwt authentication token for user</summary>
        public string GetToken(AppUser user)
        {
            // Set tokens claims
            var claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),

                // Add user Id so that UserManager.GetUserAsync can find the user based on Id
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                signingCredentials: credentials,
                expires: _timeService.Now.AddMinutes(_jwtOptions.Expires)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
