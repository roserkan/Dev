using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devs.Persistence.EntityConfigurations;

public class SocialProfileEntityConfiguration : EntityConfiguration<SocialProfile>
{
    public override void Configure(EntityTypeBuilder<SocialProfile> builder)
    {
        base.Configure(builder);

        builder.ToTable("SocialProfiles", DevsContext.DEFAULT_SCHEMA);
        builder.Property(p => p.DeveloperId).HasColumnName("DeveloperId");
        builder.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
        builder.Property(p => p.LinkedInUrl).HasColumnName("LinkedInUrl");
        builder.Property(p => p.PersonalWebSiteUrl).HasColumnName("PersonalWebSiteUrl");

        builder.HasOne(p => p.Developer);
    }
}

