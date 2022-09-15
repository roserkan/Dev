using Devs.Application.Dtos.SocialProfiles;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Commands.Create;

public class CreateSocialProfileCommand : IRequest<CreatedSocialProfileDto>
{
    public int DeveloperId { get; set; }
    public string GithubUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public string PersonalWebSiteUrl { get; set; }
}

