using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Discounts.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Discounts.Queries.GetDiscounts;

public class GetDiscountsQueryHandler : IRequestHandler<GetDiscountsQuery,BaseResponseModel<List<DiscountDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetDiscountsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<DiscountDto>>> Handle(GetDiscountsQuery request, CancellationToken cancellationToken)
    {
        List<DiscountDto> entities = await _context.Discounts
            .Where(c => (request.Title == null || c.Title.ToLower().Contains(request.Title.ToLower())))
            .ProjectTo<DiscountDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<DiscountDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}