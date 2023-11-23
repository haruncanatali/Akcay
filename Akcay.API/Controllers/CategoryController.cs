using Akcay.Application.Categories.Commands.Create;
using Akcay.Application.Categories.Commands.Delete;
using Akcay.Application.Categories.Commands.Update;
using Akcay.Application.Categories.Queries.Dtos;
using Akcay.Application.Categories.Queries.GetCategories;
using Akcay.Application.Categories.Queries.GetCategory;
using Akcay.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<CategoryDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetCategoryQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<CategoryDto>>>> Get([FromQuery]GetCategoriesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateCategoryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateCategoryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteCategoryCommand() { Id = id });
        return NoContent();
    }
}