using Core.Security.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class UserOperationClaimEntityConfiguration : EntityConfiguration<UserOperationClaim>
{
    public override void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        base.Configure(builder);

        builder.ToTable("UserOperationClaims", DevsContext.DEFAULT_SCHEMA);

        builder.Property(p => p.UserId).HasColumnName("UserId");
        builder.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

        builder.HasOne(p => p.User);
        builder.HasOne(p => p.OperationClaim);
    }
}

