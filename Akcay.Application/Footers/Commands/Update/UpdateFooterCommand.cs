using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Footers.Commands.Update;

public class UpdateFooterCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
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
    
    public class Handler : IRequestHandler<UpdateFooterCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            Footer? entity = await _context.Footers
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.UpdateErrorMessage);
            }

            entity.Location = request.Location;
            entity.Phone = request.Phone;
            entity.Mail = request.Mail;
            entity.FooterDescription = request.FooterDescription;
            entity.FacebookTitle = request.FacebookTitle;
            entity.FacebookIcon = request.FacebookIcon;
            entity.FacebookUrl = request.FacebookUrl;
            entity.XTitle = request.XTitle;
            entity.XIcon = request.XIcon;
            entity.XUrl = request.XUrl;
            entity.InstagramTitle = request.InstagramTitle;
            entity.InstagramIcon = request.InstagramIcon;
            entity.InstagramUrl = request.InstagramUrl;
            entity.PrintestTitle = request.PrintestTitle;
            entity.PrintestIcon = request.PrintestIcon;
            entity.PrintestUrl = request.PrintestUrl;
            entity.LinkedInTitle = request.LinkedInTitle;
            entity.LinkedInIcon = request.LinkedInIcon;
            entity.LinkedInUrl = request.LinkedInUrl;
            entity.OpeningDaysInMidWeek = request.OpeningDaysInMidWeek;
            entity.OpeningHoursInMidWeek = request.OpeningHoursInWeekend;
            entity.OpeningDaysInWeekend = request.OpeningDaysInMidWeek;
            entity.OpeningHoursInWeekend = request.OpeningHoursInWeekend;
            entity.EntityStatus = request.EntityStatus;

            _context.Footers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
        }
    }
}