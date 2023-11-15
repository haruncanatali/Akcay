using Akcay.Application.Bookings.Queries.Dtos;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Bookings.Queries.GetBooking;

public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery,BaseResponseModel<BookingDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetBookingQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<BookingDto>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        BookingDto? entity = await _context.Bookings
            .Where(c => c.Id == request.Id)
            .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new Exception(StaticMessages.GetErrorMessage);
        }

        return new BaseResponseModel<BookingDto>(entity, StaticMessages.GetSuccessMessage);
    }
}