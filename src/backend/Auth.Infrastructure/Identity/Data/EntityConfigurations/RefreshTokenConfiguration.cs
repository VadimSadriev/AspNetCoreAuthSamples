using Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Identity.Data.EntityConfigurations
{
    /// <summary>
    /// Configuration for <see cref="RefreshToken"/>
    /// </summary>
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Token);

            builder.Property(x => x.Token)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("token");

            builder.Property(x => x.CreateDate)
                .HasColumnName("create_date")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.Invalidated)
                .HasColumnName("invalidated");

            builder.Property(x => x.IsUsed)
                .HasColumnName("is_used");

            builder.Property(x => x.JwtId)
                .HasColumnName("jwt_id");

            builder.Property(x => x.ExpireDate)
                .HasColumnName("expire_date");

            builder.Property(x => x.AppUserId)
                .HasColumnName("user_id");

            builder.HasOne(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);

            builder.ToTable("refresh_tokens");
        }
    }
}
