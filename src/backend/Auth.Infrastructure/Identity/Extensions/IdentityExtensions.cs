using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Infrastructure.Identity.Extensions
{
    /// <summary> Extensions methods for identity </summary>
    public static class IdentityExtensions
    {
        /// <summary> transforms identity errors into string </summary>
        public static string AggregateErrors(this IEnumerable<IdentityError> errors)
        {
            return errors?.ToList()
                          .Select(f => f.Description)
                          .Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
        }
    }
}
