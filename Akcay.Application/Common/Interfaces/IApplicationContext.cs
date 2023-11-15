using Akcay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<About> Abouts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Footer> Footers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}