using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Akcay.Application.Features.Commands.Create;

public class CreateFeatureCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<CreateFeatureCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            Feature entity = new Feature
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.FeatureImagePath),
                EntityStatus = request.EntityStatus
            };

            await _context.Features.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.AddSuccessMessage);
        }
    }
}