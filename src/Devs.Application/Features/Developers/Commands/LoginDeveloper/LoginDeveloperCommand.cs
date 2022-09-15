using Core.Security.Dtos;
using Devs.Application.Dtos.Developers;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.LoginDeveloper;

public class LoginDeveloperCommand: UserForLoginDto, IRequest<TokenDto>
{
}
