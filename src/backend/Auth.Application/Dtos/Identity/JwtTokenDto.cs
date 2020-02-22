namespace Auth.Application.Dtos.Identity
{
    /// <summary>
    /// Dto for jwt and refresh token
    /// </summary>
    public class JwtTokenDto
    {
        /// <summary>
        /// Jwt token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Refresh token for jwt
        /// </summary>
        public string RefreshToken { get; set; }
    }
}