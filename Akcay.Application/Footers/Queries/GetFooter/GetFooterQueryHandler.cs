using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Application.Footers.Queries.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Footers.Queries.GetFooter;

public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery,BaseResponseModel<FooterDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetFooterQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<FooterDto>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
    {
        FooterDto? entity = await _context.Footers
            .Where(c => c.Id == request.Id)
            .ProjectTo<FooterDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<FooterDto>(entity, StaticMessages.GetSuccessMessage);
    }
}