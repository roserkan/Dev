using Core.Application.Requests;
using Devs.Application.Features.Technologies.Commands.Create;
using Devs.Application.Features.Technologies.Commands.Delete;
using Devs.Application.Features.Technologies.Commands.Update;
using Devs.Application.Features.Technologies.Queries.GetById;
using Devs.Application.Features.Technologies.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnologiesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListTechnologyQuery { PageRequest = pageRequest };
        var result = await Mediator.Send(query);
        return Ok(result);

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var query = new GetByIdTechnologyQuery { Id = id };
        var result = await Mediator.Send(query);
        return Ok(result);

    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTechnologyCommand command)
    {
        command.Id = id;
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromBody] DeleteTechnologyCommand command)
    {
        command.Id = id;
        var result = await Mediator.Send(command);
        return Ok(result);
    }

}