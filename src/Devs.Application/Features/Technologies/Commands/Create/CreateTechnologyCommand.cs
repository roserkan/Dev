using Devs.Application.Dtos.Technologies;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.Create;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
}