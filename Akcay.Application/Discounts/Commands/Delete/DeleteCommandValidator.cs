using FluentValidation;

namespace Akcay.Application.Discounts.Commands.Delete;

public class DeleteCommandValidator : AbstractValidator<DeleteDiscountCommand>
{
    public DeleteCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek indirim belirtilmelidir.");
    }
}