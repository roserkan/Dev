using Devs.Application.Dtos.Technologies;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.Update;

public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
{
    public int Id { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
}
