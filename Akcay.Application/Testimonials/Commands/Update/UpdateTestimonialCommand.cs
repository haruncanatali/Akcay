using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Akcay.Application.Testimonials.Commands.Update;

public class UpdateTestimonialCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public IFormFile? Image { get; set; }
    
    public class Handler : IRequestHandler<UpdateTestimonialCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            Testimonial? entity = await _context.Testimonials
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(StaticMessages.UpdateErrorMessage);
            }

            entity.Title = request.Title;
            entity.Name = request.Name;
            entity.Comment = request.Comment;

            if (request.Image != null)
            {
                entity.ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.TestimonialImagePath);
            }

            _context.Testimonials.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.UpdateSuccessMessage);
        }
    }
}