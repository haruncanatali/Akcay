using Akcay.Application.Common.Models;
using Akcay.Application.Testimonials.Queries.Dtos;
using MediatR;

namespace Akcay.Application.Testimonials.Queries.GetTestimonial;

public class GetTestimonialQuery : IRequest<BaseResponseModel<TestimonialDto>>
{
    public long Id { get; set; }
}