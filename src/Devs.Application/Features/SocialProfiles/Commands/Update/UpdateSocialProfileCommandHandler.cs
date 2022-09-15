using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.SocialProfiles;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Commands.Update;

public class UpdateSocialProfileCommandHandler : IRequestHandler<UpdateSocialProfileCommand, UpdatedSocialProfileDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<SocialProfile> _socialProfileRepository;

    public UpdateSocialProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _socialProfileRepository = unitOfWork.GetRepository<SocialProfile>();
    }

    public async Task<UpdatedSocialProfileDto> Handle(UpdateSocialProfileCommand request, CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisId(request.Id);

        var entity = _mapper.Map<SocialProfile>(request);
        entity = await _socialProfileRepository.UpdateAsync(entity);
        var updatedDto = _mapper.Map<UpdatedSocialProfileDto>(entity);
        return updatedDto;
    }


    private async Task IsThereRecordOfThisId(int id)
    {
        var result = await _socialProfileRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.SocialProfile_NotFound);
    }
}


