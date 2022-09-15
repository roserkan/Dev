using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class DeveloperEntityConfiguration : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.ToTable("Developers", DevsContext.DEFAULT_SCHEMA);

        builder.HasOne(p => p.SocialProfile);
    }
}