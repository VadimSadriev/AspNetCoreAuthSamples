using System;

namespace Auth.Common.Exceptions
{
    /// <summary> Business logic exception </summary>
    public class ApplicationException : Exception
    {
        /// <summary> Business logic exception </summary>
        public ApplicationException(string message) : base(message) { }
    }
}
