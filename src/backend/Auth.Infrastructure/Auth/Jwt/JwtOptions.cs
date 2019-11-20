namespace Auth.Infrastructure.Auth.Jwt
{
    /// <summary> Options for token generation </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Secret key used to generate jwt token
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Who generates token
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Who receives token
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Expire time in minutes
        /// </summary>
        public int Expires { get; set; }
    }
}
