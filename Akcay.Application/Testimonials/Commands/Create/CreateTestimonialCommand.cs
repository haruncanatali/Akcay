using Akcay.Application.Common.Interfaces;
using Akcay.Application.Common.Models;
using Akcay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Akcay.Application.Testimonials.Commands.Create;

public class CreateTestimonialCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Title { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public IFormFile Image { get; set; }
    
    public class Handler : IRequestHandler<CreateTestimonialCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly IFileService _fileService;

        public Handler(IApplicationContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            Testimonial entity = new Testimonial
            {
                Title = request.Title,
                Name = request.Name,
                Comment = request.Comment,
                ImageUrl = _fileService.UploadPhoto(request.Image, ImagePaths.TestimonialImagePath)
            };

            await _context.Testimonials.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>(Unit.Value, StaticMessages.AddErrorMessage);
        }
    }
}