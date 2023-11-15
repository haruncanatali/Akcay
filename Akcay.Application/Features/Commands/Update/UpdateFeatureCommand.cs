using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Features.Commands.Update;

public class UpdateFeatureCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile? Image { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<UpdateFeatureCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        public readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            Feature? entity = await _context.Features
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.UpdateErrorMessage);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.EntityStatus = request.EntityStatus;

            if (request.Image != null)
            {
                entity.ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.FeatureImagePath);
            }

            _context.Features.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
        }
    }
}