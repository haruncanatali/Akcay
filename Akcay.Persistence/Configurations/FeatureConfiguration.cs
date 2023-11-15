using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akcay.Persistence.Configurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.ImageUrl).IsRequired();
        builder.Property(c => c.Description).IsRequired();
    }
}