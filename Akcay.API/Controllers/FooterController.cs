using Akcay.Application.Categories.Queries.GetCategories;
using Akcay.Application.Common.Models;
using Akcay.Application.Footers.Commands.Create;
using Akcay.Application.Footers.Commands.Delete;
using Akcay.Application.Footers.Commands.Update;
using Akcay.Application.Footers.Queries.Dtos;
using Akcay.Application.Footers.Queries.GetFooters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FooterController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<FooterDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetCategoryQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<FooterDto>>>> Get([FromQuery]GetFootersQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateFooterCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateFooterCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteFooterCommand { Id = id });
        return NoContent();
    }
}