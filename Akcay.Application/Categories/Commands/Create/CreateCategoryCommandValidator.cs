using FluentValidation;

namespace Akcay.Application.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Kategori adı boş olamaz.");
    }
}