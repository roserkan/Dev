using Devs.Application.Constants;
using FluentValidation;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Update;

public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty()
           .WithMessage(Messages.ProgrammingLanguage_Id_NotEmpty);

        RuleFor(c => c.Name).NotEmpty()
            .WithMessage(Messages.ProgrammingLanguage_Name_NotEmpty);

        RuleFor(c => c.Name).MinimumLength(2)
            .WithMessage(Messages.ProgrammingLanguage_Name_MinLen);

        RuleFor(c => c.Name).MaximumLength(24)
            .WithMessage(Messages.ProgrammingLanguage_Name_MaxLen);

    }
}