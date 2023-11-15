using Akcay.Application.Abouts.Queries.Dtos;
using Akcay.Application.Common.Models;
using Akcay.Domain.Enums;
using MediatR;

namespace Akcay.Application.Abouts.Queries.GetAbouts;

public class GetAboutsQuery : IRequest<BaseResponseModel<List<AboutDto>>>
{
    public string? Title { get; set; }
    public EntityStatus? EntityStatus { get; set; }
}