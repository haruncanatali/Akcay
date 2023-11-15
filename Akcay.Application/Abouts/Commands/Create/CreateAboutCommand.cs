using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Abouts.Commands.Create;

public class CreateAboutCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    
    public class Handler : IRequestHandler<CreateAboutCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            About entity = new About
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.AboutImagePath)
            };

            List<About> activeAbouts = await _context.Abouts.Where(c => c.EntityStatus == EntityStatus.Active)
                .ToListAsync(cancellationToken);

            if (activeAbouts is { Count: > 0 })
            {
                activeAbouts.ForEach(c=>c.EntityStatus = EntityStatus.Passive);
                _context.Abouts.UpdateRange(activeAbouts);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            await _context.Abouts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value,StaticMessages.AddSuccessMessage);
        }
    }
}