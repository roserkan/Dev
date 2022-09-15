using Devs.Application.Dtos.Technologies;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.Delete;

public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
{
    public int Id { get; set; }
}
