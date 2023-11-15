using Akcay.Application.Common.Mappings;
using Akcay.Domain.Entities;
using AutoMapper;

namespace Akcay.Application.Discounts.Queries.Dtos;

public class DiscountDto : IMapFrom<Discount>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Discount, DiscountDto>();
    }
}