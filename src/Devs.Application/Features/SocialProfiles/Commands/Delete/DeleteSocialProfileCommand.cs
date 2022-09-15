using Devs.Application.Dtos.SocialProfiles;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Commands.Delete;

public class DeleteSocialProfileCommand : IRequest<DeletedSocialProfileDto>
{
    public int Id { get; set; }
}
