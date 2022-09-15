using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class ProgrammingLanguageEntityConfiguration : EntityConfiguration<ProgrammingLanguage>
{
    public override void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        base.Configure(builder);

        builder.ToTable("ProgrammingLanguages", DevsContext.DEFAULT_SCHEMA);

        builder.Property(p => p.Name)
                .IsRequired(true)
                .HasColumnName("Name")
                .HasMaxLength(20);

        builder.HasMany(p => p.Technologies)
            .WithOne(t => t.ProgrammingLanguage)
            .HasForeignKey(t => t.ProgrammingLanguageId);


    }
}

