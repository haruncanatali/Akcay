using FluentValidation;

namespace Akcay.Application.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek ürün seçilmeldir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Ürün adını giriniz.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("Ürün açıklamasını giriniz.");
        RuleFor(c => c.Price).NotNull()
            .WithMessage("Ürün fiyatını giriniz.");
        RuleFor(c => c.CategoryId).NotNull()
            .WithMessage("Ürün kategorisini giriniz.");
    }
}