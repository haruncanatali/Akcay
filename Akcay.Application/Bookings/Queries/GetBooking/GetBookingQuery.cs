using Akcay.Application.Bookings.Queries.Dtos;
using Akcay.Application.Common.Models;
using MediatR;

namespace Akcay.Application.Bookings.Queries.GetBooking;

public class GetBookingQuery : IRequest<BaseResponseModel<BookingDto>>
{
    public long Id { get; set; }
}