using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Bookings.Commands.Update;

public class UpdateBookingCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<UpdateBookingCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            Booking? entity = await _context.Bookings
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Phone = request.Phone;
                entity.Mail = request.Mail;
                entity.PersonCount = request.PersonCount;
                entity.Date = request.Date;
                entity.EntityStatus = request.EntityStatus;

                _context.Bookings.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
            }
            else
            {
                throw new Exception(StaticMessages.UpdateErrorMessage);
            }
        }
    }
}