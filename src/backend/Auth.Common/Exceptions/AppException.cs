using System;

namespace Auth.Common.Exceptions
{
    /// <summary> Business logic exception </summary>
    public class AppException : Exception
    {
        public AppException() : base() { }

        /// <summary> Business logic exception </summary>
        public AppException(string message) : base(message) { }

        /// <summary> Business logic exception </summary>
        public AppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
