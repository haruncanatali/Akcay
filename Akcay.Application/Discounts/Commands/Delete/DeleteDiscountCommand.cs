using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Discounts.Commands.Delete;

public class DeleteDiscountCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteDiscountCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount? entity = await _context.Discounts
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.DeleteErrorMessage);
            }

            _context.Discounts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
        }
    }
}