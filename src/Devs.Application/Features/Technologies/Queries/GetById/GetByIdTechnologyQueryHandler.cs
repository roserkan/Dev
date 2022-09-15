using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.Technologies;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Technologies.Queries.GetById;

public class GetByIdTechnologyQueryHandler :
IRequestHandler<GetByIdTechnologyQuery, TechnologyDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<Technology> _technologyRepository;

    public GetByIdTechnologyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _technologyRepository = unitOfWork.GetRepository<Technology>();
    }

    public async Task<TechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisId(request.Id);

        var technology = await _technologyRepository.GetAsync(predicate: p => p.Id == request.Id,
                                                              include: t => t.Include(p => p.ProgrammingLanguage));
        var mappedLanguage = _mapper.Map<TechnologyDto>(technology);
        return mappedLanguage;
    }

    public async Task IsThereRecordOfThisId(int id)
    {
        var result = await _technologyRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.Technology_NotFound);
    }
}
