using FluentValidation;

namespace Devs.Application.Features.Technologies.Commands.Update;

public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
{
    public UpdateTechnologyCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
        RuleFor(t => t.Name).NotEmpty().MinimumLength(2);
        RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
    }
}
