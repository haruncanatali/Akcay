using Akcay.Application.Common.Models;
using Akcay.Application.Products.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<BaseResponseModel<List<ProductDto>>>
{
    public string? Name { get; set; }
}