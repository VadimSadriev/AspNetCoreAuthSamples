using System;
using System.Collections.Generic;
using Auth.Application.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Identity.Exceptions
{
    /// <summary> An error occured in work with user </summary>
    public class IdentityException : AppException
    {
        /// <summary> An error occured in work with user </summary>
        public IdentityException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        /// <summary> An error occured in work with user </summary>
        public IdentityException(IEnumerable<IdentityError> errors, Exception innerException) : base("",innerException)
        {
        }

        public IEnumerable<IdentityError> Errors { get; private set; }
    }
}