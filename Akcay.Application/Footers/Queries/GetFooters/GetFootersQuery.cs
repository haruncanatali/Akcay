using Akcay.Application.Common.Models;
using Akcay.Application.Footers.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Footers.Queries.GetFooters;

public class GetFootersQuery : IRequest<BaseResponseModel<List<FooterDto>>>
{
    public string? Mail { get; set; }
}