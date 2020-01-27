using Auth.Common.Dtos.Identity;
using Auth.Common.Exceptions;
using Auth.Common.Time;
using Auth.Domain;
using Auth.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Auth.Jwt
{
    /// <summary> Service for json web token authentication </summary>
    public class JwtAuthService : IJwtAuthService
    {
        /// <summary> options for token generation </summary>
        private readonly JwtOptions _jwtOptions;

        /// <summary> Service for machine date time </summary>
        private readonly IDateTime _timeService;

        /// <summary> parameters used to validate token </summary>
        private readonly TokenValidationParameters _tokenValidationParameters;

        /// <summary>app data context </summary>
        private readonly AppDataContext _context;

        /// <summary> Service for json web token authentication </summary>
        public JwtAuthService(
            IOptions<JwtOptions> jwtOptions,
            TokenValidationParameters tokenValidationParameters,
            IDateTime timeService,
            AppDataContext context)
        {
            _jwtOptions = jwtOptions.Value;
            _tokenValidationParameters = tokenValidationParameters;
            _timeService = timeService;
            _context = context;
        }

        /// <summary> Returns new jwt authentication token for user</summary>
        public async Task<JwtTokenDto> GetToken(AppUser user)
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
                expires: _timeService.Now.DateTime.AddMinutes(_jwtOptions.Expires)
                );

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                AppUserId = user.Id,
                CreateDate = _timeService.Now.DateTime,
                ExpireDate = _timeService.Now.DateTime.AddMonths(1)
            };

            try
            {
                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new AppException("An error occurred while creating refreshing token", ex);
            }

            return new JwtTokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }

        /// <summary>
        /// Returns claims principle from jwt token
        /// </summary>
        public ClaimsPrincipal GetPrincipleFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

                if (!IsValidJwtAlghoritm(validatedToken))
                    return null;

                return principal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Validates algorithm used for passed token
        /// </summary>
        private bool IsValidJwtAlghoritm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken)
                && jwtSecurityToken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256, System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
