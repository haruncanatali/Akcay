using Akcay.Application.Common.Mappings;
using Akcay.Domain.Entities;
using AutoMapper;

namespace Akcay.Application.Testimonials.Queries.Dtos;

public class TestimonialDto : IMapFrom<Testimonial>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Testimonial, TestimonialDto>();
    }
}