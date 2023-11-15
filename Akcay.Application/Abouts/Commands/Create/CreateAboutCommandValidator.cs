using FluentValidation;

namespace Akcay.Application.Abouts.Commands.Create;

public class CreateAboutCommandValidator : AbstractValidator<CreateAboutCommand>
{
    public CreateAboutCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("Hakkımızda başlığı girilmelidir.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("Hakkımızda açıklaması girilmelidir.");
        RuleFor(c => c.Image).NotNull()
            .WithMessage("Hakkımızda fotoğrafı yüklenmelidir.");
    }
}