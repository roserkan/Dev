using Core.Application.Requests;
using Devs.Application.Models;
using MediatR;

namespace Devs.Application.Features.Technologies.Queries.GetList;

public class GetListTechnologyQuery : IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
}
