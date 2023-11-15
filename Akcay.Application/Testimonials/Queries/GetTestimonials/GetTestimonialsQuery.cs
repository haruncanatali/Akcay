using Akcay.Application.Common.Models;
using Akcay.Application.Testimonials.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Testimonials.Queries.GetTestimonials;

public class GetTestimonialsQuery : IRequest<BaseResponseModel<List<TestimonialDto>>>
{
    public string? Name { get; set; }
}