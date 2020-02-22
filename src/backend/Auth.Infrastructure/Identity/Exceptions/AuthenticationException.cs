using Auth.Application.Exceptions;

namespace Auth.Infrastructure.Identity.Exceptions
{
    /// <summary> Exception occurred during authentication failed </summary>
    public class AuthenticationException : AppException
    {
        /// <summary> Exception occurred during authentication failed </summary>
        public AuthenticationException() { }

        /// <summary> Exception occurred during authentication failed </summary>
        public AuthenticationException(string message) : base(message) { }
    }
}