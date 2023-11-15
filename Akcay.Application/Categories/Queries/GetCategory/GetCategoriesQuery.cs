using Akcay.Application.Categories.Queries.Dtos;
using Akcay.Application.Common.Models;
using MediatR;

namespace Akcay.Application.Categories.Queries.GetCategory;

public class GetCategoriesQuery : IRequest<BaseResponseModel<List<CategoryDto>>>
{
    public string? Name { get; set; }
}