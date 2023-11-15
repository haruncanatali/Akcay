using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Discounts.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Discounts.Queries.GetDiscount;

public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery,BaseResponseModel<DiscountDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetDiscountQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<DiscountDto>> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        DiscountDto? entity = await _context.Discounts
            .Where(c => c.Id == request.Id)
            .ProjectTo<DiscountDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<DiscountDto>(entity, StaticMessages.GetSuccessMessage);
    }
}