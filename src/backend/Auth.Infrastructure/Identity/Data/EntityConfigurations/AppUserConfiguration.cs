using Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Identity.Data.EntityConfigurations
{
    /// <summary> Configuration for <see cref="AppUser"/> </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        /// <summary> Configuration </summary>
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
