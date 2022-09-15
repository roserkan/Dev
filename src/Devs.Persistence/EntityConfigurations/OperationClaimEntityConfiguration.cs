using Core.Security.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class OperationClaimEntityConfiguration : EntityConfiguration<OperationClaim>
{
    public override void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        base.Configure(builder);

        builder.ToTable("OperationClaims", DevsContext.DEFAULT_SCHEMA);

        builder.Property(p => p.Name).HasColumnName("Name");


    }
}
