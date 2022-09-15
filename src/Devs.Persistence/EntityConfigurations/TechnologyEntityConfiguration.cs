using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class TechnologyEntityConfiguration : EntityConfiguration<Technology>
{
    public override void Configure(EntityTypeBuilder<Technology> builder)
    {
        base.Configure(builder);

        builder.ToTable("Technologies", DevsContext.DEFAULT_SCHEMA);

        builder.Property(t => t.ProgrammingLanguageId)
               .IsRequired(true)
               .HasColumnName("ProgrammingLanguageId");

        builder.Property(t => t.Name)
                .IsRequired(true)
                .HasColumnName("Name");

        builder.HasOne(t => t.ProgrammingLanguage)
            .WithMany(p => p.Technologies)
            .HasForeignKey(t => t.ProgrammingLanguageId);


    }
}

