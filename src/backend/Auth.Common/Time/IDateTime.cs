using System;

namespace Auth.Common.Time
{
    /// <summary> Service for machine date time </summary>
    public interface IDateTime
    {
        /// <summary> Current machine time </summary>
        DateTimeOffset Now => DateTimeOffset.Now;
    }
}