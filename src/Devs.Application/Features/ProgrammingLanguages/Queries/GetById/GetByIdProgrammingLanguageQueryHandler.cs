using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.ProgrammingLanguages;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Queries.GetById;

public class GetByIdProgrammingLanguageQueryHandler :
    IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;

    public GetByIdProgrammingLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _programmingLanguageRepository = unitOfWork.GetRepository<ProgrammingLanguage>();
    }

    public async Task<ProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisId(request.Id);

        var language = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
        var mappedLanguage = _mapper.Map<ProgrammingLanguageDto>(language);
        return mappedLanguage;
    }

    public async Task IsThereRecordOfThisId(int id)
    {
        var result = await _programmingLanguageRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguage_NotFound);
    }
}