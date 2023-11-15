using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteCategoryCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? entity = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
            }

            throw new Exception(StaticMessages.DeleteErrorMessage);
        }
    }
}