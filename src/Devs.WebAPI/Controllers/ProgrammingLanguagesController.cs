using Core.Application.Requests;
using Devs.Application.Features.ProgrammingLanguages.Commands.Create;
using Devs.Application.Features.ProgrammingLanguages.Commands.Delete;
using Devs.Application.Features.ProgrammingLanguages.Commands.Update;
using Devs.Application.Features.ProgrammingLanguages.Queries.GetById;
using Devs.Application.Features.ProgrammingLanguages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListProgrammingLanguageQuery { PageRequest = pageRequest };
        var result = await Mediator.Send(query);
        return Ok(result);

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var query = new GetByIdProgrammingLanguageQuery { Id = id };
        var result = await Mediator.Send(query);
        return Ok(result);

    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProgrammingLanguageCommand command)
    {
        command.Id = id;
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromBody] DeleteProgrammingLanguageCommand command)
    {
        command.Id = id;
        var result = await Mediator.Send(command);
        return Ok(result);
    }

}