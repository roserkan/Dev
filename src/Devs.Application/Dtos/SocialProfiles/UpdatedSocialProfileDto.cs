namespace Devs.Application.Dtos.SocialProfiles;

public class UpdatedSocialProfileDto
{
    public int Id { get; set; }
    public int DeveloperId { get; set; }
    public string GithubUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public string PersonalWebSiteUrl { get; set; }

}
