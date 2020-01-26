namespace Auth.Common.Dtos.Identity
{
    /// <summary> Response dto for jwt authentication </summary>
    public class UserJwtResponseDto : UserResponseDto
    {
        /// <summary> Jwt auth token </summary>
        public string Token { get; set; }

        /// <summary> Token used to refresh jwt </summary>
        public string RefreshToken { get; set; }
    }
}