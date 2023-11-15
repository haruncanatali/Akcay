using Akcay.Application.Common.Mappings;
using Akcay.Domain.Entities;
using AutoMapper;

namespace Akcay.Application.Features.Queries.Dtos;

public class FeatureDto : IMapFrom<Feature>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Feature, FeatureDto>();
    }
}