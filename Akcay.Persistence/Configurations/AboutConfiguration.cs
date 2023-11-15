using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akcay.Persistence.Configurations;

public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.ImageUrl).IsRequired();
    }
}