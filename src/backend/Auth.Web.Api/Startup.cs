using Auth.Application;
using Auth.Common.Dtos.Identity;
using Auth.Infrastructure;
using Auth.Web.Infrastructure.Contracts.AccountContracts;
using Auth.Web.Infrastructure.MIddlewares;
using Auth.Web.Infrastructure.Swagger;
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
            services.AddInfrastructure(Configuration, typeof(UserResponseContract).Assembly);
            services.AddJwtAuthentication(Configuration);

            var assembliesWithMOdels = new[]
            {
                Assembly.GetExecutingAssembly(),
                typeof(UserResponseDto).Assembly,
                typeof(UserSigninContract).Assembly
            };

            services.AddSwagger(assembliesWithMOdels);

            services.AddCors();
            services.AddControllers();
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
