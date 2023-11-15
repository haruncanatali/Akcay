using Akcay.Application.Common.Mappings;
using Akcay.Domain.Entities;
using AutoMapper;

namespace Akcay.Application.Products.Queries.Dtos;

public class ProductDto : IMapFrom<Product>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public long CategoryId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>();
    }
}