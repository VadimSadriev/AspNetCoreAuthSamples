namespace Auth.Application.Dtos.Identity
{
    /// <summary> Dto used for refreshing jwt token </summary>
    public class RefreshJwtTokenDto
    {
        /// <summary> Expired Jwt auth token </summary>
        public string Token { get; set; }

        /// <summary> Token used to refreshing jwt </summary>
        public string RefreshToken { get; set; }
    }
}