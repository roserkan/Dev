using Devs.Application.Dtos.SocialProfiles;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Commands.Update;

public class UpdateSocialProfileCommand : IRequest<UpdatedSocialProfileDto>
{
    public int Id { get; set; }
    public int DeveloperId { get; set; }
    public string GithubUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public string PersonalWebSiteUrl { get; set; }
}
