using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akcay.Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Amount).IsRequired();
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.ImageUrl).IsRequired();
    }
}