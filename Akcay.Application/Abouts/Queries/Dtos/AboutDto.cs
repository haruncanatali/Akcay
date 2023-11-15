using Akcay.Application.Common.Mappings;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using AutoMapper;

namespace Akcay.Application.Abouts.Queries.Dtos;

public class AboutDto : IMapFrom<About>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EntityStatus EntityStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<About, AboutDto>();
    }
}