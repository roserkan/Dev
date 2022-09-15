using Core.Application.Requests;
using Devs.Application.Features.SocialProfiles.Commands.Create;
using Devs.Application.Features.SocialProfiles.Commands.Delete;
using Devs.Application.Features.SocialProfiles.Commands.Update;
using Devs.Application.Features.SocialProfiles.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

public class SocialProfilesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListSocialProfileQuery { PageRequest = pageRequest };
        var result = await Mediator.Send(query);
        return Ok(result);

    }

    //[HttpGet("{id:int}")]
    //public async Task<ActionResult> GetById(int id)
    //{
    //    var query = new GetByIdSocialProfileQuery { Id = id };
    //    var result = await Mediator.Send(query);
    //    return Ok(result);

    //}

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSocialProfileCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSocialProfileCommand command)
    {
        command.Id = id;
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromBody] DeleteSocialProfileCommand command)
    {
        command.Id = id;
        var result = await Mediator.Send(command);
        return Ok(result);
    }

}
