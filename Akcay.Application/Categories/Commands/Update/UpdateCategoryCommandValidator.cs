using FluentValidation;

namespace Akcay.Application.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Güncellenecek kategori geçilmelidir.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("Güncellenecek kategorinin durumu girilmelidir.");
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Kategori adı boş olamaz.");
    }
}