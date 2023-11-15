using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akcay.Persistence.Configurations;

public class FooterConfiguration : IEntityTypeConfiguration<Footer>
{
    public void Configure(EntityTypeBuilder<Footer> builder)
    {
        builder.Property(c => c.Location).IsRequired();
        builder.Property(c => c.Phone).IsRequired();
        builder.Property(c => c.Mail).IsRequired();
        builder.Property(c => c.FooterDescription).IsRequired();
        builder.Property(c => c.FacebookIcon).IsRequired();
        builder.Property(c => c.FacebookTitle).IsRequired();
        builder.Property(c => c.FacebookUrl).IsRequired();
        builder.Property(c => c.InstagramIcon).IsRequired();
        builder.Property(c => c.InstagramTitle).IsRequired();
        builder.Property(c => c.InstagramUrl).IsRequired();
        builder.Property(c => c.XIcon).IsRequired();
        builder.Property(c => c.XTitle).IsRequired();
        builder.Property(c => c.XUrl).IsRequired();
        builder.Property(c => c.PrintestIcon).IsRequired();
        builder.Property(c => c.PrintestTitle).IsRequired();
        builder.Property(c => c.PrintestUrl).IsRequired();
        builder.Property(c => c.LinkedInIcon).IsRequired();
        builder.Property(c => c.LinkedInTitle).IsRequired();
        builder.Property(c => c.LinkedInUrl).IsRequired();
        builder.Property(c => c.OpeningDaysInWeekend).IsRequired();
        builder.Property(c => c.OpeningHoursInWeekend).IsRequired();
        builder.Property(c => c.OpeningDaysInMidWeek).IsRequired();
        builder.Property(c => c.OpeningHoursInMidWeek).IsRequired();
    }
}