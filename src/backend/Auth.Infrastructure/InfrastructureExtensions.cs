﻿using Auth.Common.Time;
using Auth.Infrastructure.Auth.Jwt;
using Auth.Infrastructure.Identity;
using Auth.Infrastructure.Time;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Reflection;
using Auth.Domain;
using Microsoft.AspNetCore.Identity;
using Auth.Application;
using Auth.Application.Common.Interfaces.Identity;

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

            // identity
            services.AddIdentity<AppUser, IdentityRole>()
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

            // mappings
            var mapperAsemblies = new[]
            {
                typeof(ApplicationExtensions).Assembly,
                Assembly.GetExecutingAssembly()
            };

            services.AddAutoMapper(mapperAsemblies);

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
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
                });

            return services;
        }
    }
}
