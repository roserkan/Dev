using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.ProgrammingLanguages;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommandHandler :
    IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;

    public CreateProgrammingLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _programmingLanguageRepository = unitOfWork.GetRepository<ProgrammingLanguage>();
    }

    public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

        var mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
        var createdLanguage = await _programmingLanguageRepository.AddAsync(mappedLanguage);
        var createdLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdLanguage);
        return createdLanguageDto;
    }



    public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
        var result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguage_Name_Exists);
    }
}