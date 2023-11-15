using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Discounts.Commands.Update;

public class UpdateDiscountCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public IFormFile? Image { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<UpdateDiscountCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount? entity = await _context.Discounts
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.UpdateErrorMessage);
            }

            if (request.Image != null)
            {
                entity.ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.DiscountImagePath);
            }

            entity.Title = request.Title;
            entity.Amount = request.Amount;
            entity.Description = request.Description;
            entity.EntityStatus = request.EntityStatus;

            _context.Discounts.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
        }
    }
}