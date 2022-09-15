using Devs.Application.Dtos.ProgrammingLanguages;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Update;

public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}