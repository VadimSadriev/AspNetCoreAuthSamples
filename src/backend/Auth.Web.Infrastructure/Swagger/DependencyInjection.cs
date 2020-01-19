using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
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