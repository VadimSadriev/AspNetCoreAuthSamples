using Auth.Common.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth.IntergrationTests.Extensions
{
    /// <summary>
    /// Extensions for <see cref="HttpContent"/>
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Reads content as <see cref="Task{T}"/>
        /// </summary>
        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            var stremContent = await httpContent.ReadAsStreamAsync();

            return await stremContent.ReadAsAsync<T>();
        }
    }
}