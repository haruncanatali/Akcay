using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akcay.Persistence.Configurations;

public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Comment).IsRequired();
        builder.Property(c => c.ImageUrl).IsRequired();
    }
}