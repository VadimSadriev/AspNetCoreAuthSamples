using Auth.Application.Behaviours;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Auth.Application
{
    /// <summary> Extensions method for application layer </summary>
    public static class DependencyInjection
    {
        /// <summary> Adds application layer to application </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

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
