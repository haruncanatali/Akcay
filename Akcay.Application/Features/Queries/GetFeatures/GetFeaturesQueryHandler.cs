using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Features.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Features.Queries.GetFeatures;

public class GetFeaturesQueryHandler : IRequestHandler<GetFeaturesQuery,BaseResponseModel<List<FeatureDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetFeaturesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<FeatureDto>>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
    {
        List<FeatureDto> entities = await _context.Features
            .Where(c => (request.Title == null || c.Title.ToLower().Contains(request.Title.ToLower())))
            .ProjectTo<FeatureDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<FeatureDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}