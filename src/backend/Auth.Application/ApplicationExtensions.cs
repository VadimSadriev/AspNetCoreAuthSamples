using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Auth.Application
{
    /// <summary> Extensions method for application layer </summary>
    public static class ApplicationExtensions
    {
        /// <summary> Adds application layer to application </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // mappings
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
