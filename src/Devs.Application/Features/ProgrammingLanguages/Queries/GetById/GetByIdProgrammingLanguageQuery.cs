using Devs.Application.Dtos.ProgrammingLanguages;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Queries.GetById;

public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageDto>
{
    public int Id { get; set; }
}