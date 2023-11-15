using Akcay.Application.Categories.Queries.Dtos;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Categories.Queries.GetCategory;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery,BaseResponseModel<List<CategoryDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<CategoryDto> entities = await _context.Categories
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .Include(c => c.Products)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<CategoryDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}