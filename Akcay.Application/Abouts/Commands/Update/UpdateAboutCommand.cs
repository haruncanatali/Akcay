using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using Akcay.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Abouts.Commands.Update;

public class UpdateAboutCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile? Image { get; set; }
    public EntityStatus EntityStatus { get; set; }
    
    public class Handler : IRequestHandler<UpdateAboutCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            About? entity = await _context.Abouts.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                entity.Title = request.Title;
                entity.Description = request.Description;
                entity.EntityStatus = request.EntityStatus;

                if (request.Image != null)
                {
                    entity.ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.AboutImagePath);
                }

                List<About> otherActiveAbouts = await _context
                    .Abouts
                    .Where(c => c.Id != request.Id && c.EntityStatus == EntityStatus.Active)
                    .ToListAsync(cancellationToken);

                if (otherActiveAbouts is { Count: > 0 } && request.EntityStatus == EntityStatus.Active)
                {
                    otherActiveAbouts.ForEach(c=>c.EntityStatus = EntityStatus.Passive);
                    _context.Abouts.UpdateRange(otherActiveAbouts);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                _context.Abouts.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
            }

            throw new Exception(StaticMessages.UpdateErrorMessage);
        }
    }
}