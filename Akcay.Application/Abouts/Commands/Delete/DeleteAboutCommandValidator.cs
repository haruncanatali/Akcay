using FluentValidation;

namespace Akcay.Application.Abouts.Commands.Delete;

public class DeleteAboutCommandValidator : AbstractValidator<DeleteAboutCommand>
{
    public DeleteAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek hakkımızda varlığı seçilmelidir.");
    }
}