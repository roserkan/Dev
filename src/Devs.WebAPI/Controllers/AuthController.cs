using Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Devs.Application.Features.Developers.Commands.LoginDeveloper;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand createDeveloperCommand)
    {
        var result = await Mediator.Send(createDeveloperCommand);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDeveloperCommand loginDeveloperCommand)
    {
        var result = await Mediator.Send(loginDeveloperCommand);

        return Ok(result);
    }

}
