using Devs.Application.Dtos.ProgrammingLanguages;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }
}