using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Testimonials.Commands.Delete;

public class DeleteTestimonialCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteTestimonialCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            Testimonial? entity = await _context.Testimonials
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.DeleteErrorMessage);
            }

            _context.Testimonials.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
        }
    }
}