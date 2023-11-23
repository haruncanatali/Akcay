using Akcay.Application.Common.Models;
using Akcay.Application.Testimonials.Commands.Create;
using Akcay.Application.Testimonials.Commands.Delete;
using Akcay.Application.Testimonials.Commands.Update;
using Akcay.Application.Testimonials.Queries.Dtos;
using Akcay.Application.Testimonials.Queries.GetTestimonial;
using Akcay.Application.Testimonials.Queries.GetTestimonials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestimonialController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<TestimonialDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetTestimonialQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<TestimonialDto>>>> Get([FromQuery]GetTestimonialsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateTestimonialCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateTestimonialCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteTestimonialCommand { Id = id });
        return NoContent();
    }
}