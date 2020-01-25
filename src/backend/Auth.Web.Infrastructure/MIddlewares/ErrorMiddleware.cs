using Auth.Common.Dtos.Exception;
using Auth.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auth.Web.Infrastructure.MIddlewares
{
    /// <summary>
    /// Handles all exception occurred during request
    /// </summary>
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandleAsync(httpContext, ex);
            }
        }

        private async Task HandleAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/json";

            var exceptionDto = new ExceptionDto
            {
                Errors = new[] { new ExceptionErrorDto { Message = exception.Message } }
            };

            var result = JsonSerializer.Serialize<ExceptionDto>(exceptionDto, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await httpContext.Response.WriteAsync(result);
        }
    }
}
