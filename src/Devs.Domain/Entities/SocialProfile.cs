using Core.Persistence.Repositories;

namespace Devs.Domain.Entities;

public class SocialProfile : Entity
{
    public int DeveloperId { get; set; }
    public virtual Developer Developer { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? PersonalWebSiteUrl { get; set; }
}
