using Devs.Application.Constants;
using FluentValidation;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage(Messages.ProgrammingLanguage_Name_NotEmpty);

        RuleFor(c => c.Name).MinimumLength(2)
            .WithMessage(Messages.ProgrammingLanguage_Name_MinLen);

        RuleFor(c => c.Name).MaximumLength(24)
            .WithMessage(Messages.ProgrammingLanguage_Name_MaxLen);

    }
}