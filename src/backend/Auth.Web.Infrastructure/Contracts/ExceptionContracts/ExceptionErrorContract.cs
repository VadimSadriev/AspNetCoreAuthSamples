namespace Auth.Web.Infrastructure.Contracts.ExceptionContracts
{
    /// <summary> Contract for exception error </summary>
    public class ExceptionErrorContract
    {
        /// <summary> Error message </summary>
        public string Message { get; set; }

        /// <summary> Type of exception </summary>
        public string Type { get; set; }
    }
}
