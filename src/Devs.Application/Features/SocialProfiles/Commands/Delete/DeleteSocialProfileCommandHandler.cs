using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.SocialProfiles;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Commands.Delete;

public class DeleteSocialProfileCommandHandler : IRequestHandler<DeleteSocialProfileCommand, DeletedSocialProfileDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<SocialProfile> _socialProfileRepository;

    public DeleteSocialProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _socialProfileRepository = unitOfWork.GetRepository<SocialProfile>();
    }

    public async Task<DeletedSocialProfileDto> Handle(DeleteSocialProfileCommand request,
        CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisId(request.Id);

        var entity = await _socialProfileRepository.GetAsync(g => g.Id == request.Id);
        entity = await _socialProfileRepository.DeleteAsync(entity);
        var deletedDto = _mapper.Map<DeletedSocialProfileDto>(entity);
        return deletedDto;
    }

    private async Task IsThereRecordOfThisId(int id)
    {
        var result = await _socialProfileRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.SocialProfile_NotFound);
    }
}
