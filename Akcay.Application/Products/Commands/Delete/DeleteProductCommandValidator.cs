using FluentValidation;

namespace Akcay.Application.Products.Commands.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek ürün seçilmeldir.");
    }
}