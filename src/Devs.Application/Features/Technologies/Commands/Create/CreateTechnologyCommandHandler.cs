using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.Technologies;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Technologies.Commands.Create;

public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<Technology> _technologyRepository;
    private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;


    public CreateTechnologyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _technologyRepository = unitOfWork.GetRepository<Technology>();
        _programmingLanguageRepository = unitOfWork.GetRepository<ProgrammingLanguage>();
    }
    public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisProgrammingLanguage(request.ProgrammingLanguageId);
        await TechnologyNameCanNotBeDuplicatedWhenUpdated(request.Name);

        var mappedTechnology = _mapper.Map<Technology>(request);
        var createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);

        var createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology);

        return createdTechnologyDto;
    }

    public async Task TechnologyNameCanNotBeDuplicatedWhenUpdated(string name)
    {
        var result = await _technologyRepository.GetListAsync(p => p.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.Technology_Name_Exists);
    }

    public async Task IsThereRecordOfThisProgrammingLanguage(int id)
    {
        var result = await _programmingLanguageRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.Technology_NotFound);
    }
}