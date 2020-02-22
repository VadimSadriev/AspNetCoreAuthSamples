using System;

namespace Auth.Application.Exceptions
{
    /// <summary> Business logic exception </summary>
    public class AppException : Exception
    {
        /// <summary> Business logic exception </summary>
        public AppException() : base() { }

        /// <summary> Business logic exception </summary>
        public AppException(string message) : base(message) { }

        /// <summary> Business logic exception </summary>
        public AppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
