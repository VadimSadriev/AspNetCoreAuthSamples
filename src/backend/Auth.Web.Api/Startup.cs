using Auth.Application;
using Auth.Application.Dtos.Identity;
using Auth.Contracts.AccountContracts;
using Auth.Infrastructure;
using Auth.Infrastructure.Mapping.Profiles;
using Auth.Web.Infrastructure.ContractValidators.AccountValidators;
using Auth.Web.Infrastructure.Filters;
using Auth.Web.Infrastructure.MappingProfiles;
using Auth.Web.Infrastructure.Middlewares;
using Auth.Web.Infrastructure.Swagger;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Auth.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddJwtAuthentication(Configuration);

            var assembliesWithModels = new[]
            {
                Assembly.GetExecutingAssembly(),
                typeof(UserSigninContract).Assembly
            };

            services.AddSwagger(assembliesWithModels);

            services.AddCors();
            services.AddControllers(options =>
                {
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssemblyContaining<UserCreateContractValidator>();
                    config.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            var assembliesWithProfiles = new[]
            {
                typeof(AccountProfiles).Assembly,
                typeof(UserCreateContract).Assembly,
                typeof(UserProfile).Assembly
            };

            services.AddMapping(assembliesWithProfiles);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger(Configuration);
            app.UseMiddleware<ErrorMiddleware>();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
