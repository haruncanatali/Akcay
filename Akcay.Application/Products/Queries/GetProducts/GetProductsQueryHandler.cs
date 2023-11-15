using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Products.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery,BaseResponseModel<List<ProductDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<ProductDto> entities = await _context.Products
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<ProductDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}