namespace Akcay.Domain.Entities;

public class Footer : BaseEntity
{
    public string Location { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    
    public string FooterDescription { get; set; }
    
    public string FacebookTitle { get; set; }
    public string FacebookIcon { get; set; }
    public string FacebookUrl { get; set; }
    
    public string XTitle { get; set; }
    public string XIcon { get; set; }
    public string XUrl { get; set; }
    
    public string InstagramTitle { get; set; }
    public string InstagramIcon { get; set; }
    public string InstagramUrl { get; set; }
    
    public string PrintestTitle { get; set; }
    public string PrintestIcon { get; set; }
    public string PrintestUrl { get; set; }
    
    public string LinkedInTitle { get; set; }
    public string LinkedInIcon { get; set; }
    public string LinkedInUrl { get; set; }

    public string OpeningDaysInMidWeek { get; set; }
    public string OpeningHoursInMidWeek { get; set; }
    
    public string OpeningDaysInWeekend { get; set; }
    public string OpeningHoursInWeekend { get; set; }
}