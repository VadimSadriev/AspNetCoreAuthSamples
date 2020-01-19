using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Auth.Web.Infrastructure.Swagger
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add swagger to application
        /// </summary>
        public static IServiceCollection AddSwagger(this IServiceCollection services, params Assembly[] assembliesWithModels)
        {
            var xmlFilePaths = assembliesWithModels
                .Select(x => Path.Combine(AppContext.BaseDirectory, $"{x.GetName().Name}.xml"));

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Api v1", Version = "v1" });
                x.DescribeAllParametersInCamelCase();

                foreach (var xmlFilePath in xmlFilePaths)
                {
                    x.IncludeXmlComments(xmlFilePath);
                }

                // solution for configuring authorization due to breaking changes because of new swagger version
                // https://stackoverflow.com/questions/58197244/swaggerui-with-netcore-3-0-bearer-token-authorization
                var openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };

                var security = new OpenApiSecurityRequirement();
                security.Add(openApiSecurityScheme, new[] { "Bearer" });

                x.AddSecurityDefinition("Bearer", openApiSecurityScheme);

                x.AddSecurityRequirement(security);
            });

            return services;
        }

        /// <summary>
        /// Use swagger in application
        /// </summary>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerOptinsSection = configuration.GetSection("SwaggerOptions");

            if (!swaggerOptinsSection.Exists())
                throw new ArgumentNullException($"Configuration {swaggerOptinsSection.Key} not found");

            var swaggerOptions = new SwaggerOptions();

            swaggerOptinsSection.Bind(swaggerOptions);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });

            return app;
        }
    }
}