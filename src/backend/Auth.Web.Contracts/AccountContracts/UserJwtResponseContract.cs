namespace Auth.Web.Contracts.AccountContracts
{
    /// <summary> Response contract for jwt authentication </summary>
    public class UserJwtResponseContract
    {
        /// <summary> Jwt auth token </summary>
        public string Token { get; set; }

        /// <summary> Token used to refresh jwt </summary>
        public string RefreshToken { get; set; }
    }
}
