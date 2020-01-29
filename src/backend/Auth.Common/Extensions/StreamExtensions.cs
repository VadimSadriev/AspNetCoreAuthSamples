using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Auth.Common.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Stream"/>
    /// </summary>
    public static class StreamExtensions
    {
        private static readonly JsonSerializerOptions DefaultJsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };

        static StreamExtensions()
        {
            DefaultJsonOptions.Converters.Add(new JsonStringEnumConverter());
        }

        /// <summary>
        /// Reads stream as <see cref="Task{T}"/>
        /// </summary>
        public static async Task<T> ReadAsAsync<T>(this Stream content)
        {
            return await JsonSerializer.DeserializeAsync<T>(content, DefaultJsonOptions);
        }
    }
}