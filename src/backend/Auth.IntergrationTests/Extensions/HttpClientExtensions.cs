using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auth.IntergrationTests.Extensions
{
    /// <summary>
    /// Extensions for <see cref="HttpClient"/>
    /// </summary>
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var serialized = JsonSerializer.Serialize(data);

            var content = new StringContent(serialized);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await httpClient.PostAsync(url, content);
        }
    }
}
