using FluentValidation;

namespace Akcay.Application.Discounts.Commands.Update;

public class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommand>
{
    public UpdateDiscountCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek indirim belirtilmelidir.");
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("İndirim başlığı boş olamaz.");
        RuleFor(c => c.Amount).NotNull()
            .WithMessage("İndirim miktarı boş olamaz.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("İndirim açıklaması boş olamaz.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("İndirim durumu boş olamaz.");
    }
}