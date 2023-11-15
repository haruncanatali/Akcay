using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;

namespace Akcay.Application.Bookings.Commands.Create;

public class CreateBookingCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
    
    public class Handler : IRequestHandler<CreateBookingCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            await _context.Bookings.AddAsync(new Booking
            {
                Name = request.Name,
                Phone = request.Phone,
                Mail = request.Mail,
                PersonCount = request.PersonCount,
                Date = request.Date
            }, cancellationToken);


            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.AddSuccessMessage);
        }
    }
}