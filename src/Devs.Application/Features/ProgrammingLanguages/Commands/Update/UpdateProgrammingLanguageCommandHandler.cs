using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.ProgrammingLanguages;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Update;

public class UpdateProgrammingLanguageCommandHandler :
    IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;

    public UpdateProgrammingLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _programmingLanguageRepository = unitOfWork.GetRepository<ProgrammingLanguage>();
    }

    public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await LanguageNameCanNotBeDuplicatedWhenUpdated(request.Name);
        await IsThereRecordOfThisId(request.Id);

        var mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
        var updatedLanguage = await _programmingLanguageRepository.UpdateAsync(mappedLanguage);
        var updatedLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedLanguage);

        return updatedLanguageDto;
    }



    public async Task LanguageNameCanNotBeDuplicatedWhenUpdated(string name)
    {
        var result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguage_Name_Exists);
    }

    public async Task IsThereRecordOfThisId(int id)
    {
        var result = await _programmingLanguageRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguage_NotFound);
    }
}