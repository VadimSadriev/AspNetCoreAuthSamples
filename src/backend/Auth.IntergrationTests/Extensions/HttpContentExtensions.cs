using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auth.IntergrationTests.Extensions
{
    /// <summary>
    /// Extensions for <see cref="HttpContent"/>
    /// </summary>
    public static class HttpContentExtensions
    {
        public static async ValueTask<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            var str = await httpContent.ReadAsStringAsync();
            var stremContent = await httpContent.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(stremContent);
        }
    }
}