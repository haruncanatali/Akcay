using Akcay.Application.Common.Models;
using Akcay.Application.Discounts.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Discounts.Queries.GetDiscounts;

public class GetDiscountsQuery : IRequest<BaseResponseModel<List<DiscountDto>>>
{
    public string? Title { get; set; }
}