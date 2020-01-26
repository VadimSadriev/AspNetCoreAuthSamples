using Auth.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Auth.Infrastructure.Identity
{
    /// <summary> Main context for application users </summary>
    public class AppDataContext : IdentityDbContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        /// <summary> Main context for application users </summary>
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
