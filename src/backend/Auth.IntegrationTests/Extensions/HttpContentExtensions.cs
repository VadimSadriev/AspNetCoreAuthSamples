using System.Net.Http;
using System.Threading.Tasks;
using Auth.Common.Extensions;

namespace Auth.IntegrationTests.Extensions
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