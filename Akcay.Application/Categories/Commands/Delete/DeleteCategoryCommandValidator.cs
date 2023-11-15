using FluentValidation;

namespace Akcay.Application.Categories.Commands.Delete;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek kategori geçilmelidir.");
    }
}