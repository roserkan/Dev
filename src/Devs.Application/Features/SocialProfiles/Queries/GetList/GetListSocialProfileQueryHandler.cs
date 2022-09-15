using AutoMapper;
using Core.Persistence.Repositories;
using Devs.Application.Interfaces.Repositories;
using Devs.Application.Models;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Queries.GetList;

public class GetListSocialProfileQueryHandler : IRequestHandler<GetListSocialProfileQuery, SocialProfileListModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<SocialProfile> _socialProfileRepository;

    public GetListSocialProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _socialProfileRepository = unitOfWork.GetRepository<SocialProfile>();
    }

    public async Task<SocialProfileListModel> Handle(GetListSocialProfileQuery request, CancellationToken cancellationToken)
    {
        var result = await _socialProfileRepository
            .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        var listModel = _mapper.Map<SocialProfileListModel>(result);

        return listModel;
    }
}