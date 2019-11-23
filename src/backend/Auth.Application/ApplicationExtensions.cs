using Microsoft.Extensions.DependencyInjection;

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
    }
}
