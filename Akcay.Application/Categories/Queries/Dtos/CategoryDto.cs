using Akcay.Application.Common.Mappings;
using Akcay.Application.Products.Queries.Dtos;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using AutoMapper;

namespace Akcay.Application.Categories.Queries.Dtos;

public class CategoryDto : IMapFrom<Category>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<ProductDto> Products { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EntityStatus EntityStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Products, opt=>
                opt.MapFrom(c=>c.Products));
    }
}