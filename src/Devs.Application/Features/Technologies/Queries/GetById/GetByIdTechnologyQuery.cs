using Devs.Application.Dtos.Technologies;
using MediatR;

namespace Devs.Application.Features.Technologies.Queries.GetById;

public class GetByIdTechnologyQuery : IRequest<TechnologyDto>
{
    public int Id { get; set; }
}
