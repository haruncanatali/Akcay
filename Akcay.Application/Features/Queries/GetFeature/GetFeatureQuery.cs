using Akcay.Application.Common.Models;
using Akcay.Application.Features.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Features.Queries.GetFeature;

public class GetFeatureQuery : IRequest<BaseResponseModel<FeatureDto>>
{
    public long Id { get; set; }
}