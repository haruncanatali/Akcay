using Akcay.Application.Bookings.Queries.Dtos;
using Akcay.Application.Common.Models;
using MediatR;

namespace Akcay.Application.Bookings.Queries.GetBookings;

public class GetBookingsQuery : IRequest<BaseResponseModel<List<BookingDto>>>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mail { get; set; }
    public int? PersonCount { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? CreatedAt { get; set; }
}