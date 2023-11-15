using FluentValidation;

namespace Akcay.Application.Testimonials.Commands.Update;

public class UpdateTestimonialCommandValidator : AbstractValidator<UpdateTestimonialCommand>
{
    public UpdateTestimonialCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek referans seçilmelidir.");
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("Referans başlığı girilmelidir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Referans adı girilmelidir.");
        RuleFor(c => c.Comment).NotEmpty()
            .WithMessage("Referans yorumu girilmelidir.");
    }
}