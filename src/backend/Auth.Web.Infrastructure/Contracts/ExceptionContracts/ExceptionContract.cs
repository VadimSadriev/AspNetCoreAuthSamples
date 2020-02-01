using System;
using System.Collections.Generic;

namespace Auth.Web.Infrastructure.Contracts.ExceptionContracts
{
    /// <summary>
    /// Contract error for consumers in case of any <see cref="Exception"/>
    /// </summary>
    public class ExceptionContract
    {
        /// <summary> Exception errors </summary>
        public ICollection<ExceptionErrorContract> Errors { get; set; }
    }
}
