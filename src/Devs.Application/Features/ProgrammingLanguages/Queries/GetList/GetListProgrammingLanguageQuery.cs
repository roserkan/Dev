using Core.Application.Requests;
using Devs.Application.Models;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Queries.GetList;

public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
}

