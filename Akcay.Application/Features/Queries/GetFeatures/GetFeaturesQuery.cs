using Akcay.Application.Common.Models;
using Akcay.Application.Features.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Features.Queries.GetFeatures;

public class GetFeaturesQuery : IRequest<BaseResponseModel<List<FeatureDto>>>
{
    public string? Title { get; set; }
}