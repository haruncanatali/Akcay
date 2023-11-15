using Akcay.Application.Common.Models;
using Akcay.Application.Discounts.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Discounts.Queries.GetDiscount;

public class GetDiscountQuery : IRequest<BaseResponseModel<DiscountDto>>
{
    public long Id { get; set; }
}