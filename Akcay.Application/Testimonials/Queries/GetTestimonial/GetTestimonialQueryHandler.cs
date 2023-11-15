using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Testimonials.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Testimonials.Queries.GetTestimonial;

public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery,BaseResponseModel<TestimonialDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetTestimonialQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<TestimonialDto>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        TestimonialDto? entity = await _context.Testimonials
            .Where(c => c.Id == request.Id)
            .ProjectTo<TestimonialDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<TestimonialDto>(entity, StaticMessages.GetSuccessMessage);
    }
}