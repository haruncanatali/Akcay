using FluentValidation;

namespace Akcay.Application.Features.Commands.Delete;

public class DeleteFeatureCommandValidator : AbstractValidator<DeleteFeatureCommand>
{
    public DeleteFeatureCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek öne çıkan yazısı seçilmelidir.");
    }
}