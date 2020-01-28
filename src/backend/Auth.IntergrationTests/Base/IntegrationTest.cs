using Auth.Infrastructure.Identity;
using Auth.Web.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;

namespace Auth.IntergrationTests.Base
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(AppDataContext));
                        services.AddDbContext<AppDataContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });
                    });
                });

            using var scope = appFactory.Services.CreateScope();

            var context = scope.ServiceProvider.GetService<AppDataContext>();
           // context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            TestClient = appFactory.CreateClient();
        }
    }
}
