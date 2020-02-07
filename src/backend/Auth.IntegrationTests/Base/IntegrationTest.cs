using System;
using System.Net.Http;
using System.Threading.Tasks;
using Auth.Infrastructure.Identity;
using Auth.Web.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Auth.IntegrationTests.Base
{
    public class IntegrationTest : IAsyncDisposable
    {
        protected readonly HttpClient TestClient;
        private readonly IServiceProvider _serviceProvider;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // https://github.com/dotnet/extensions/issues/2800
                        services.RemoveAll<DbContextOptions<AppDataContext>>();
                        services.AddDbContext<AppDataContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            _serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }

        public async ValueTask DisposeAsync()
        {
            using var serviceScope = _serviceProvider.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<AppDataContext>();
            
            await context.Database.EnsureDeletedAsync();
        }
    }
}