using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Products.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Products.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery,BaseResponseModel<ProductDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        ProductDto? entity = await _context.Products
            .Where(c => c.Id == request.Id)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<ProductDto>(entity, StaticMessages.GetSuccessMessage);
    }
}