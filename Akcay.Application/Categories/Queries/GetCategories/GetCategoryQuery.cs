using Akcay.Application.Categories.Queries.Dtos;
using Akcay.Application.Common.Models;
using MediatR;

namespace Akcay.Application.Categories.Queries.GetCategories;

public class GetCategoryQuery : IRequest<BaseResponseModel<CategoryDto>>
{
    public long Id { get; set; }
}