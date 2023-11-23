using Akcay.Application.Abouts.Commands.Create;
using Akcay.Application.Abouts.Commands.Delete;
using Akcay.Application.Abouts.Commands.Update;
using Akcay.Application.Abouts.Queries.Dtos;
using Akcay.Application.Abouts.Queries.GetAbout;
using Akcay.Application.Abouts.Queries.GetAbouts;
using Akcay.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AboutController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<AboutDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetAboutQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<AboutDto>>>> Get([FromQuery]GetAboutsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateAboutCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateAboutCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteAboutCommand { Id = id });
        return NoContent();
    }
}