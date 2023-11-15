using FluentValidation;

namespace Akcay.Application.Bookings.Commands.Create;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Adınızı ve soyadınızı giriniz.");
        RuleFor(c => c.Phone).NotEmpty()
            .WithMessage("Telefon numaranızı giriniz.");
        RuleFor(c => c.Mail).NotEmpty()
            .WithMessage("Mail adresinizi giriniz.");
        RuleFor(c => c.PersonCount).NotNull()
            .WithMessage("Kişi sayısı giriniz.");
        RuleFor(c => c.Date).NotEmpty()
            .WithMessage("Rezervasyon tarihini giriniz.");
    }
}