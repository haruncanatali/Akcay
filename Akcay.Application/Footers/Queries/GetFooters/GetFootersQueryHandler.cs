using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Footers.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Footers.Queries.GetFooters;

public class GetFootersQueryHandler : IRequestHandler<GetFootersQuery,BaseResponseModel<List<FooterDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetFootersQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<FooterDto>>> Handle(GetFootersQuery request, CancellationToken cancellationToken)
    {
        List<FooterDto> entities = await _context.Footers
            .Where(c => (request.Mail == null || c.Mail.ToLower().Contains(request.Mail.ToLower())))
            .ProjectTo<FooterDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<FooterDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}