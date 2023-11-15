using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Testimonials.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Testimonials.Queries.GetTestimonials;

public class GetTestimonialsQueryHandler : IRequestHandler<GetTestimonialsQuery,BaseResponseModel<List<TestimonialDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetTestimonialsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<TestimonialDto>>> Handle(GetTestimonialsQuery request, CancellationToken cancellationToken)
    {
        List<TestimonialDto> entities = await _context.Testimonials
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .ProjectTo<TestimonialDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<TestimonialDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}