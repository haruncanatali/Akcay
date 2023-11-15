using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Features.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Features.Queries.GetFeature;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery,BaseResponseModel<FeatureDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetFeatureQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<FeatureDto>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        FeatureDto? entity = await _context.Features
            .Where(c => c.Id == request.Id)
            .ProjectTo<FeatureDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<FeatureDto>(entity, StaticMessages.GetSuccessMessage);
    }
}