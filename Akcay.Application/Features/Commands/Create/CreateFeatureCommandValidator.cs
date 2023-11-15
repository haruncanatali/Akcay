using FluentValidation;

namespace Akcay.Application.Features.Commands.Create;

public class CreateFeatureCommandValidator : AbstractValidator<CreateFeatureCommand>
{
    public CreateFeatureCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("Öne çıkan yazısının başlığı girilmelidir.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("Öne çıkan yazısının içeriği girilmelidir.");
        RuleFor(c => c.Image).NotNull()
            .WithMessage("Öne çıkan yazısının resmi girilmelidir.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("Öne çıkan yazısının durumu belirtilmelidir.");
    }
}