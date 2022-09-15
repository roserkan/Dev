using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Constants;
using Devs.Application.Dtos.Developers;
using Devs.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Developers.Commands.LoginDeveloper;

public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, TokenDto>
{
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<User> _userRepository;

    public LoginDeveloperCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _unitOfWork = unitOfWork;
        _userRepository = _unitOfWork.GetRepository<User>();
    }


    public async Task<TokenDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(
            u => u.Email.ToLower() == request.Email.ToLower(),
            include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));

        List<OperationClaim> operationClaims = new List<OperationClaim>() { };

        foreach (var userOperationClaim in user.UserOperationClaims)
        {
            operationClaims.Add(userOperationClaim.OperationClaim);
        }

        IsThereUser(user);

        IsUserCredentialsMatch(request.Password, user.PasswordHash, user.PasswordSalt);

        AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

        TokenDto tokenDto = _mapper.Map<TokenDto>(token);

        return tokenDto;
    }

    private void IsThereUser(User user)
    {
        if (user == null) throw new BusinessException(Messages.User_NotFound);
    }


    private void IsUserCredentialsMatch(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
        if (!result) throw new BusinessException(Messages.User_CredentialsError);
    }
}
