using Auth.Web.Contracts.ExceptionContracts;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ErrorMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
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

            var exceptionContract = _mapper.Map<ExceptionContract>(exception);

            var result = JsonSerializer.Serialize
                (exceptionContract, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await httpContext.Response.WriteAsync(result);
        }
    }
}
