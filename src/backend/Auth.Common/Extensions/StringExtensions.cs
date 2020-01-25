using System.Text.RegularExpressions;

namespace Auth.Common.Extensions
{
    /// <summary>
    /// Contains extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks string for valid email address
        /// </summary>
        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
    }
}
