using Akcay.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Akcay.Application.Products.Commands.Create;

public class CreateProductCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile Image { get; set; }
    public long CategoryId { get; set; }
}