using Core.Security.Dtos;
using Devs.Application.Dtos.Developers;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.CreateDeveloper;

public class RegisterUserCommand : UserForRegisterDto, IRequest<TokenDto>
{

}
