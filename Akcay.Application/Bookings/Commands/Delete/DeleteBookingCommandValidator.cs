using FluentValidation;

namespace Akcay.Application.Bookings.Commands.Delete;

public class DeleteBookingCommandValidator : AbstractValidator<DeleteBookingCommand>
{
    public DeleteBookingCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Silinecek rezervasyon seçilmelidir.");
    }
}