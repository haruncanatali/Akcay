using Akcay.Application.Categories.Queries.Dtos;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Categories.Queries.GetCategories;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,BaseResponseModel<CategoryDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        CategoryDto? entity = await _context
            .Categories
            .Where(c => c.Id == request.Id)
            .Include(c=>c.Products)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<CategoryDto>(entity, StaticMessages.GetSuccessMessage);
    }
}