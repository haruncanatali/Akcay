using Akcay.Application.Abouts.Queries.Dtos;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Abouts.Queries.GetAbouts;

public class GetAboutsQueryHandler : IRequestHandler<GetAboutsQuery,BaseResponseModel<List<AboutDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetAboutsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<AboutDto>>> Handle(GetAboutsQuery request, CancellationToken cancellationToken)
    {
        List<AboutDto> abouts = await _context.Abouts
            .Where(c =>
                (request.Title == null || c.Title.ToLower().Contains(request.Title.ToLower()) &&
                    (request.EntityStatus == null || c.EntityStatus == request.EntityStatus)))
            .ProjectTo<AboutDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<AboutDto>>(abouts, StaticMessages.GetSuccessMessage);
    }
}