using FluentValidation;

namespace Akcay.Application.Discounts.Commands.Create;

public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
{
    public CreateDiscountCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("İndirim başlığı boş olamaz.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("İndirim açıklaması boş olamaz.");
        RuleFor(c => c.Image).NotNull()
            .WithMessage("İndirim görseli boş olamaz.");
        RuleFor(c => c.Amount).NotNull()
            .WithMessage("İndirim miktarı boş olamaz.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("İndirim durumu boş olamaz.");
    }
}