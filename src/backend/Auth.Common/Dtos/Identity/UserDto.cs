namespace Auth.Common.Dtos.Identity
{
    /// <summary> Dto for <see cref="AppUser"/> </summary>
    public class UserDto
    {
        /// <summary> Name of user </summary>
        public string UserName { get; set; }

        /// <summary> Email </summary>
        public string Email { get; set; }
    }
}
