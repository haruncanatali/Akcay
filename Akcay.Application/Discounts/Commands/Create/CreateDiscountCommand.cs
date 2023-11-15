using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Akcay.Application.Discounts.Commands.Create;

public class CreateDiscountCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<CreateDiscountCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount entity = new Discount
            {
                Title = request.Title,
                Amount = request.Amount,
                Description = request.Description,
                ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.DiscountImagePath),
                EntityStatus = request.EntityStatus
            };

            await _context.Discounts.AddAsync(entity, cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.AddSuccessMessage);
        }
    }
}