namespace Auth.Web.Infrastructure.Contracts.AccountContracts
{
    /// <summary>
    /// Contract for user signin
    /// </summary>
    public class UserSigninContract
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
