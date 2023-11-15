using FluentValidation;

namespace Akcay.Application.Testimonials.Commands.Create;

public class CreateTestimonialCommandValidator : AbstractValidator<CreateTestimonialCommand>
{
    public CreateTestimonialCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("Referans başlığı girilmelidir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Referans adı girilmelidir.");
        RuleFor(c => c.Comment).NotEmpty()
            .WithMessage("Referans yorumu girilmelidir.");
        RuleFor(c => c.Image).NotNull()
            .WithMessage("Referans fotoğrafı girilmelidir.");
    }
}