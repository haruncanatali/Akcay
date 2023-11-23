using Akcay.Application.Common.Models;
using Akcay.Application.Products.Commands.Create;
using Akcay.Application.Products.Commands.Delete;
using Akcay.Application.Products.Commands.Update;
using Akcay.Application.Products.Queries.Dtos;
using Akcay.Application.Products.Queries.GetProduct;
using Akcay.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akcay.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<ProductDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetProductQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<List<ProductDto>>>> Get([FromQuery]GetProductsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(CreateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update(UpdateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        await Mediator.Send(new DeleteProductCommand { Id = id });
        return NoContent();
    }
}