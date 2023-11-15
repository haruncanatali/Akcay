using Akcay.Domain.Enums;

namespace Akcay.Domain.Entities;

public class About : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}