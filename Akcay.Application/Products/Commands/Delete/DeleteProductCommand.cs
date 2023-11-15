using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteProductCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? entity = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.DeleteErrorMessage);
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
        }
    }
}