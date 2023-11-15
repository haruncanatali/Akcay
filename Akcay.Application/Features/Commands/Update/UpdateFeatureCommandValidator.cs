using FluentValidation;

namespace Akcay.Application.Features.Commands.Update;

public class UpdateFeatureCommandValidator : AbstractValidator<UpdateFeatureCommand>
{
    public UpdateFeatureCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek öne çıkan yazısı seçilmelidir.");
        RuleFor(c => c.Title).NotEmpty()
            .WithMessage("Öne çıkan yazısının başlığı girilmelidir.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("Öne çıkan yazısının içeriği girilmelidir.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("Öne çıkan yazısının durumu belirtilmelidir.");
    }
}