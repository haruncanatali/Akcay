using Akcay.Application.Common.Models;
using Akcay.Application.Products.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Products.Queries.GetProduct;

public class GetProductQuery : IRequest<BaseResponseModel<ProductDto>>
{
    public long Id { get; set; }
}