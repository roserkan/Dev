using AutoMapper;
using Core.Persistence.Repositories;
using Devs.Application.Interfaces.Repositories;
using Devs.Application.Models;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Technologies.Queries.GetList;

public class GetListTechnologyQueryHandler :
    IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<Technology> _technologyRepository;

    public GetListTechnologyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _technologyRepository = unitOfWork.GetRepository<Technology>();
    }

    public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
    {

        var technologies = await _technologyRepository.GetListAsync(include: t => t.Include(p => p.ProgrammingLanguage),
                                                                    index: request.PageRequest.Page, 
                                                                    size: request.PageRequest.PageSize);

        var mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(technologies);

        return mappedTechnologyListModel;
    }

}