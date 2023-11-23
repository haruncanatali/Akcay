using Akcay.Application.Common.Models;
using Akcay.Application.Features.Commands.Create;
using Akcay.Application.Features.Commands.Delete;
using Akcay.Application.Features.Commands.Update;
using Akcay.Application.Features.Queries.Dtos;
using Akcay.Application.Features.Queries.GetFeature;
using Akcay.Application.Features.Queries.GetFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<FeatureDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetFeatureQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<FeatureDto>>>> Get([FromQuery]GetFeaturesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateFeatureCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateFeatureCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteFeatureCommand { Id = id });
        return NoContent();
    }
}