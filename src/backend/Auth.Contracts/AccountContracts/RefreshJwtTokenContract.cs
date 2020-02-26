namespace Auth.Contracts.AccountContracts
{
    /// <summary> Contract used for refreshing jwt token </summary>
    public class RefreshJwtTokenContract
    {
        /// <summary> Expired Jwt auth token </summary>
        public string Token { get; set; }

        /// <summary> Token used to refreshing jwt </summary>
        public string RefreshToken { get; set; }
    }
}