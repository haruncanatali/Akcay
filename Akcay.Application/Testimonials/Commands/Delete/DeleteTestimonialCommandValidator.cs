using FluentValidation;

namespace Akcay.Application.Testimonials.Commands.Delete;

public class DeleteTestimonialCommandValidator : AbstractValidator<DeleteTestimonialCommand>
{
    public DeleteTestimonialCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek referans seçilmelidir.");
    }
}