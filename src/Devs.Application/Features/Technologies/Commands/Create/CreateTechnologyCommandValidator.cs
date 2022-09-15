using FluentValidation;

namespace Devs.Application.Features.Technologies.Commands.Create;

public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
{
    public CreateTechnologyCommandValidator()
    {
        RuleFor(t => t.Name).NotEmpty().MinimumLength(2);
        RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
    }
}