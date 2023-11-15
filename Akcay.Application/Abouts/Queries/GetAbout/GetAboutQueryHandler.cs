using Akcay.Application.Abouts.Queries.Dtos;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Abouts.Queries.GetAbout;

public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery,BaseResponseModel<AboutDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetAboutQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<AboutDto>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
    {
        AboutDto? entity =  await _context
            .Abouts
            .Where(c => c.Id == request.Id)
            .ProjectTo<AboutDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity != null)
        {
            return new BaseResponseModel<AboutDto>(entity, StaticMessages.GetSuccessMessage);
        }

        throw new Exception(StaticMessages.GetErrorMessage);
    }
}