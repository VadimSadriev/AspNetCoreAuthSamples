using Auth.Application.Exceptions;

namespace Auth.Infrastructure.Identity.Exceptions
{
    /// <summary> Exception occurred during signing in </summary>
    public class SigninException : AppException
    {
        public SigninException() : this("An error occurred during signing in") { }

        public SigninException(string message) : base(message) { }
    }
}
