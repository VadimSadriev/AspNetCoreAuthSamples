namespace Auth.Web.Contracts.AccountContracts
{
    /// <summary> Response contract for consumer </summary>
    public class UserResponseContract
    {
        /// <summary> Name of user </summary>
        public string UserName { get; set; }

        /// <summary> Email </summary>
        public string Email { get; set; }
    }
}
