namespace Auth.Web.Infrastructure.Contracts.AccountContracts
{
    /// <summary> Contract for user creation </summary>
    public class UserCreateContract
    {
        /// <summary> Name or login for the user </summary>
        public string UserName { get; set; }

        /// <summary> Email </summary>
        public string Email { get; set; }

        /// <summary> User password </summary>
        public string Password { get; set; }
    }
}