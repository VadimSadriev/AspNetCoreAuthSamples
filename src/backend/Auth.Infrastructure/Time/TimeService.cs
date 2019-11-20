using Auth.Common.Time;
using System;

namespace Auth.Infrastructure.Time
{
    /// <summary> Service for machine date time </summary>
    public class TimeService : IDateTime
    {
        /// <summary> Current machine time </summary>
        public DateTime Now => DateTime.UtcNow;
    }
}
