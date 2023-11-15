using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Footers.Commands.Delete;

public class DeleteFooterCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteFooterCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteFooterCommand request, CancellationToken cancellationToken)
        {
            Footer? footer = await _context.Footers
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (footer == null)
            {
                throw new Exception(StaticMessages.DeleteErrorMessage);
            }

            _context.Footers.Remove(footer);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
        }
    }
}