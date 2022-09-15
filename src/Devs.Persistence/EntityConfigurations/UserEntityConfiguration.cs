using Core.Security.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class UserEntityConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users", DevsContext.DEFAULT_SCHEMA);

        builder.Property(p => p.FirstName).HasColumnName("FirstName");
        builder.Property(p => p.LastName).HasColumnName("LastName");
        builder.Property(p => p.Email).HasColumnName("Email");
        builder.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
        builder.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
        builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

        builder.HasMany(p => p.UserOperationClaims);
        builder.HasMany(p => p.RefreshTokens);

    }
}
