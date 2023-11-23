using Akcay.Application.Bookings.Commands.Create;
using Akcay.Application.Bookings.Commands.Delete;
using Akcay.Application.Bookings.Commands.Update;
using Akcay.Application.Bookings.Queries.Dtos;
using Akcay.Application.Bookings.Queries.GetBooking;
using Akcay.Application.Bookings.Queries.GetBookings;
using Akcay.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<BookingDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetBookingQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<BookingDto>>>> Get([FromQuery]GetBookingsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateBookingCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateBookingCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteBookingCommand() { Id = id });
        return NoContent();
    }
}