using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Products.Commands.Update;

public class UpdateProductCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price  { get; set; }
    public long CategoryId { get; set; }
    public IFormFile? Image { get; set; }
    
    public class Handler : IRequestHandler<UpdateProductCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? entity = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.UpdateErrorMessage);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.CategoryId = request.CategoryId;

            if (request.Image != null)
            {
                entity.ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.ProductImagePath);
            }

            _context.Products.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
        }
    }
}