using Auth.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    /// <summary> Extensions for infrastructure layer </summary>
    public static class InfrastructureExtensions
    {
        /// <summary> Adds infrastructure layer to application </summary>
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDataContext>(options =>
            {
                options.UseSqlite(configuration["Database:UserStore"]);
                options.EnableSensitiveDataLogging();
            });

            return service;
        }
    }
}
