using FluentValidation;

namespace Devs.Application.Features.SocialProfiles.Commands.Update;

public class UpdateSocialProfileCommandValidator : AbstractValidator<UpdateSocialProfileCommand>
{
    public UpdateSocialProfileCommandValidator()
    {
        RuleFor(s => s.DeveloperId).NotEmpty();
    }
}
