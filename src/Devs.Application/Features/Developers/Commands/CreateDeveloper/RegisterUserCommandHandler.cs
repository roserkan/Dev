using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Constants;
using Devs.Application.Dtos.Developers;
using Devs.Application.Interfaces.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.CreateDeveloper;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TokenDto>
{
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Developer> _developerRepository;
    private readonly IRepository<User> _userRepository;


    public RegisterUserCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _unitOfWork = unitOfWork;
        _developerRepository = _unitOfWork.GetRepository<Developer>();
        _userRepository = _unitOfWork.GetRepository<User>();

    }

    public async Task<TokenDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        await EmailCanNotBeDuplicatedWhenInserted(request.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var developer = _mapper.Map<Developer>(request);
        developer.PasswordHash = passwordHash;
        developer.PasswordSalt = passwordSalt;

        var createdDeveloper = await _developerRepository.AddAsync(developer);

        var token = _tokenHelper.CreateToken(developer, new List<OperationClaim>());

        return new() { Token = token.Token, Expiration = token.Expiration };
    }

    public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
    {
        var result = await _userRepository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        if (result != null) throw new BusinessException(Messages.User_Email_AlreadyExist);
    }
}
