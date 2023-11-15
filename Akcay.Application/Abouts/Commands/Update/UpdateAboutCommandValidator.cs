using FluentValidation;

namespace Akcay.Application.Abouts.Commands.Update;

public class UpdateAboutCommandValidator : AbstractValidator<UpdateAboutCommand>
{
    public UpdateAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Güncellenecek hakkımızda varlığı seçilmelidir.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("Güncellenecek hakkımızda varlığının aktiflik durumu seçilmelidir.");
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("Hakkımızda başlığı girilmelidir.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("Hakkımızda açıklaması girilmelidir.");
    }
}