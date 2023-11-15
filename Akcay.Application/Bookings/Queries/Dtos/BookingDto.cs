using Akcay.Application.Common.Mappings;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using AutoMapper;

namespace Akcay.Application.Bookings.Queries.Dtos;

public class BookingDto : IMapFrom<Booking>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EntityStatus EntityStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Booking, BookingDto>();
    }
}