using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<UpdateCategoryCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? entity = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.EntityStatus = request.EntityStatus;

                _context.Categories.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
            }

            throw new Exception(StaticMessages.UpdateErrorMessage);
        }
    }
}