using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;

namespace Akcay.Application.Footers.Commands.Create;

public class CreateFooterCommand : IRequest<BaseResponseModel<Unit>>
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
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<CreateFooterCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            await _context.Footers.AddAsync(new Footer
            {
                Location = request.Location,
                Phone = request.Phone,
                Mail = request.Mail,
                FooterDescription = request.FooterDescription,
                FacebookTitle = request.FacebookTitle,
                FacebookIcon = request.FacebookIcon,
                FacebookUrl = request.FacebookUrl,
                XTitle = request.XTitle,
                XIcon = request.XIcon,
                XUrl = request.XUrl,
                InstagramTitle = request.InstagramTitle,
                InstagramIcon = request.InstagramIcon,
                InstagramUrl = request.InstagramUrl,
                PrintestTitle = request.PrintestTitle,
                PrintestIcon = request.PrintestIcon,
                PrintestUrl = request.PrintestUrl,
                LinkedInTitle = request.LinkedInTitle,
                LinkedInIcon = request.LinkedInIcon,
                LinkedInUrl = request.LinkedInUrl,
                OpeningDaysInWeekend = request.OpeningDaysInWeekend,
                OpeningHoursInWeekend = request.OpeningHoursInWeekend,
                OpeningDaysInMidWeek = request.OpeningDaysInMidWeek,
                OpeningHoursInMidWeek = request.OpeningHoursInMidWeek,
                EntityStatus = request.EntityStatus
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.AddSuccessMessage);
        }
    }
}