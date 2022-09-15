using AutoMapper;
using Core.Persistence.Repositories;
using Devs.Application.Interfaces.Repositories;
using Devs.Application.Models;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.ProgrammingLanguages.Queries.GetList;

public class GetListProgrammingLanguageQueryHandler :
    IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;

    public GetListProgrammingLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _programmingLanguageRepository = unitOfWork.GetRepository<ProgrammingLanguage>();
    }

    public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {

        var languages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        var mappedLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(languages);

        return mappedLanguageListModel;
    }

}