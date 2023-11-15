using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Bookings.Commands.Delete;

public class DeleteBookingCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteBookingCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            Booking? entity = await _context.Bookings
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                _context.Bookings.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
            }
            else
            {
                throw new Exception(StaticMessages.DeleteErrorMessage);
            }
        }
    }
}