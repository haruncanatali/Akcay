using Akcay.Application.Common.Models;
using Akcay.Application.Discounts.Commands.Create;
using Akcay.Application.Discounts.Commands.Delete;
using Akcay.Application.Discounts.Commands.Update;
using Akcay.Application.Discounts.Queries.Dtos;
using Akcay.Application.Discounts.Queries.GetDiscount;
using Akcay.Application.Discounts.Queries.GetDiscounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscountController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<DiscountDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetDiscountQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<DiscountDto>>>> Get([FromQuery]GetDiscountsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateDiscountCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateDiscountCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteDiscountCommand() { Id = id });
        return NoContent();
    }
}