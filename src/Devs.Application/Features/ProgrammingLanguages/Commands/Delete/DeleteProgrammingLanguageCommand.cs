using Devs.Application.Dtos.ProgrammingLanguages;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Delete;

public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
{
    public int Id { get; set; }
}