using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Time;
using Auth.Domain;
using Auth.Infrastructure.Auth.Jwt;
using Auth.Infrastructure.Identity;
using Auth.Infrastructure.Identity.Configuration;
using Auth.Infrastructure.Identity.Services;
using Auth.Infrastructure.Time;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace Auth.Infrastructure
{
    /// <summary> Extensions for infrastructure layer </summary>
    public static class InfrastructureExtensions
    {
        /// <summary> Adds infrastructure layer to application </summary>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // register user database
            services.AddDbContext<AppDataContext>(options =>
            {
                options.UseSqlite(configuration["Database:UserStore"]);
                options.EnableSensitiveDataLogging();
            });

            var identityConfigurationSection = configuration.GetSection("IdentityOptions");

            var identityConfiguration = new IdentityConfiguration();

            identityConfigurationSection.Bind(identityConfiguration);

            // identity
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = identityConfiguration.RequireDigit;
                options.Password.RequiredLength = identityConfiguration.RequiredLength;
                options.Password.RequiredUniqueChars = identityConfiguration.RequiredUniqueChars;
                options.Password.RequireLowercase = identityConfiguration.RequireLowercase;
                options.Password.RequireNonAlphanumeric = identityConfiguration.RequireNonAlphanumeric;
                options.Password.RequireUppercase = identityConfiguration.RequireUppercase;
            })
             .AddEntityFrameworkStores<AppDataContext>()
             .AddDefaultTokenProviders();

            services.AddScoped<IUserManager, UserManagerService>();

            // time service
            services.AddTransient<IDateTime, TimeService>();

            // serilog
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddSerilog(
                    new LoggerConfiguration().ReadFrom.Configuration(configuration.GetSection("Logging"))
                        .CreateLogger());
            });

            return services;
        }

        /// <summary>
        /// Adds default cookie authentication to application
        /// </summary>
        public static IServiceCollection AddCookieAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

            return services;
        }

        /// <summary>
        /// Adds json web token authentication to application
        /// </summary>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("Authentication:Jwt"));

            services.AddTransient<IJwtAuthService, JwtAuthService>();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                // set issuer
                ValidIssuer = configuration["Authentication:Jwt:Issuer"],
                // Set audience
                ValidAudience = configuration["Authentication:Jwt:Audience"],
                // Set signing key
                IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:SecretKey"]))
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;
                });

            return services;
        }
    }
}
