using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akcay.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Phone).IsRequired();
        builder.Property(c => c.Mail).IsRequired();
        builder.Property(c => c.PersonCount).IsRequired();
        builder.Property(c => c.Date).IsRequired();
    }
}