using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.SocialProfiles;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.SocialProfiles.Commands.Create;

public class CreateSocialProfileCommandHandler : IRequestHandler<CreateSocialProfileCommand, CreatedSocialProfileDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<SocialProfile> _socialProfileRepository;

    public CreateSocialProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _socialProfileRepository = unitOfWork.GetRepository<SocialProfile>();
    }

    public async Task<CreatedSocialProfileDto> Handle(CreateSocialProfileCommand request, CancellationToken cancellationToken)
    {
        await SocialProfileUrlsCanNotBeDuplicatedWhenCreated(request.DeveloperId);

        var entity = _mapper.Map<SocialProfile>(request);
        entity = await _socialProfileRepository.AddAsync(entity);
        var createdDto = _mapper.Map<CreatedSocialProfileDto>(entity);
        return createdDto;
    }

    private async Task SocialProfileUrlsCanNotBeDuplicatedWhenCreated(int developerId)
    {
        var developer = await _socialProfileRepository.GetAsync(s => s.DeveloperId == developerId);
        if (developer == null) throw new BusinessException(Messages.SocialProfile_DeveloperId_NotFound);
        if (developer.GithubUrl != null) throw new BusinessException(Messages.SocialProfile_DeveloperId_NotFound);
        if (developer.LinkedInUrl != null) throw new BusinessException(Messages.SocialProfile_LinkedinUrl_AlreadyExist);
        if (developer.PersonalWebSiteUrl != null) throw new BusinessException(Messages.SocialProfile_PersonalWebSiteUrl_AlreadyExist);
    }
}

