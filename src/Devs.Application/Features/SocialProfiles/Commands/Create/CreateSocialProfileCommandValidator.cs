using FluentValidation;

namespace Devs.Application.Features.SocialProfiles.Commands.Create;

public class CreateSocialProfileCommandValidator : AbstractValidator<CreateSocialProfileCommand>
{
    public CreateSocialProfileCommandValidator()
    {
        RuleFor(s => s.DeveloperId).NotEmpty();
    }
}
