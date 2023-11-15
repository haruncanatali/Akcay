using Akcay.Application.Bookings.Queries.Dtos;
using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Bookings.Queries.GetBookings;

public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery,BaseResponseModel<List<BookingDto>>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetBookingsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<List<BookingDto>>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        List<BookingDto> entities = await _context.Bookings
            .Where(c =>
                (request.PersonCount == null || c.PersonCount == request.PersonCount)
                &&
                (request.CreatedAt == null || c.CreatedAt.Date == request.CreatedAt.Value.Date)
                &&
                (request.Date == null || c.Date.Date == request.Date.Value.Date)
                &&
                (request.Phone == null || c.Phone.ToLower().Contains(request.Phone.ToLower()))
                &&
                (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower()))
                &&
                (request.Mail == null || c.Mail.ToUpper().Contains(request.Mail.ToLower())))
            .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new BaseResponseModel<List<BookingDto>>(entities, StaticMessages.GetSuccessMessage);
    }
}