namespace Auth.Application.Dtos.Identity
{
    /// <summary> Dto for Application user
    public class UserResponseDto
    {
        /// <summary> Name of user </summary>
        public string UserName { get; set; }

        /// <summary> Email </summary>
        public string Email { get; set; }
    }
}
