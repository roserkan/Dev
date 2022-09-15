using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Devs.Application.Constants;
using Devs.Application.Dtos.Technologies;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.Delete;

public class DeleteTechnologyCommandHandler :
    IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRepository<Technology> _technologyRepository;

    public DeleteTechnologyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _technologyRepository = unitOfWork.GetRepository<Technology>();
    }

    public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
    {
        await IsThereRecordOfThisId(request.Id);

        var mappedTechnology = _mapper.Map<Technology>(request);
        var deletedTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);
        var deletedLanguateDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
        return deletedLanguateDto;
    }


    public async Task IsThereRecordOfThisId(int id)
    {
        var result = await _technologyRepository.GetListAsync(p => p.Id == id);
        if (!result.Items.Any()) throw new BusinessException(Messages.Technology_NotFound);
    }
}
