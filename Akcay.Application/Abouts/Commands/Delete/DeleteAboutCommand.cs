using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Abouts.Commands.Delete;

public class DeleteAboutCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteAboutCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            About? entity = await _context.Abouts.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                _context.Abouts.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.DeleteSuccessMessage);
            }

            throw new Exception(StaticMessages.DeleteErrorMessage);
        }
    }
}