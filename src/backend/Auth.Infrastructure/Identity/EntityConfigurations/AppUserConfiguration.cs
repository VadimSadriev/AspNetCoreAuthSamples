using Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Auth.Infrastructure.Identity.EntityConfigurations
{
    /// <summary> Configuration for <see cref="AppUser"/> </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        /// <summary> Configuration </summary>
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
        }
    }
}
