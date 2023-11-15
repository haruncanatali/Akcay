using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Akcay.Application.Products.Commands.Create;

public class CreateProductCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile Image { get; set; }
    public long CategoryId { get; set; }
    
    public class Handler : IRequestHandler<CreateProductCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.ProductImagePath)
            };

            await _context.Products.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.AddSuccessMessage);
        }
    }
}