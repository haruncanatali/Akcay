using FluentValidation;

namespace Akcay.Application.Footers.Commands.Delete;

public class DeleteFooterCommandValidator : AbstractValidator<DeleteFooterCommand>
{
    public DeleteFooterCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek footer seçilmelidir.");
    }
}