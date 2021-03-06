﻿using Auth.Application.Common.Interfaces.Identity;
using Auth.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Auth.Infrastructure.Identity.Data
{
    /// <summary> Main context for application users </summary>
    public class AppDataContext : IdentityDbContext<AppUser, IdentityRole, string>, IUserDataContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        /// <summary> Main context for application users </summary>
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
