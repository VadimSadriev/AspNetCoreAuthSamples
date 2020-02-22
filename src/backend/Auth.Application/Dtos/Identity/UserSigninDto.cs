namespace Auth.Application.Dtos.Identity
{
    /// <summary>
    /// Dto for user signin
    /// </summary>
    public class UserSigninDto
    {
        /// <summary>
        /// Username or email to signin
        /// </summary>
        public string UserNameOrEmail { get; set; }

        /// <summary>
        /// Account password
        /// </summary>
        public string Password { get; set; }
    }
}
