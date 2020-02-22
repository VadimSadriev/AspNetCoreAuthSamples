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
            return services;
        }

        /// <summary> Adds mapping profiles from given assemblies </summary>
        public static IServiceCollection AddMapping(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
