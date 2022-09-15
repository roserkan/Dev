using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.ProgrammingLanguages;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Delete;

public class DeleteProgrammingLanguageCommandHandler :
    IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;

    public DeleteProgrammingLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _programmingLanguageRepository = unitOfWork.GetRepository<ProgrammingLanguage>();
    }

    public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisId(request.Id);

        var mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
        var deletedLanguage = await _programmingLanguageRepository.DeleteAsync(mappedLanguage);
        var deletedLanguateDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedLanguage);
        return deletedLanguateDto;
    }


    public async Task IsThereRecordOfThisId(int id)
    {
        var result = await _programmingLanguageRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguage_NotFound);
    }
}