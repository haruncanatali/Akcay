using FluentValidation;

namespace Akcay.Application.Footers.Commands.Create;

public class CreateFooterCommandValidator : AbstractValidator<CreateFooterCommand>
{
    public CreateFooterCommandValidator()
    {
        RuleFor(c => c.Location).NotEmpty()
            .WithMessage("Lokasyon bilgisi girilmeldir.");
        RuleFor(c => c.Phone).NotEmpty()
            .WithMessage("Telefon bilgisi girilmelidir.");
        RuleFor(c => c.Mail).NotEmpty()
            .WithMessage("Mail bilgisi girilmelidir.");
        RuleFor(c => c.FooterDescription).NotEmpty()
            .WithMessage("Açıklama bilgisi girilmelidir.");
        RuleFor(c => c.FacebookTitle).NotEmpty()
            .WithMessage("Facebook başlık bilgisi girilmelidir.");
        RuleFor(c => c.FacebookIcon).NotEmpty()
            .WithMessage("Facebook ikon bilgisi girilmelidir.");
        RuleFor(c => c.FacebookUrl).NotEmpty()
            .WithMessage("Facebook URL bilgisi girilmelidir.");
        RuleFor(c => c.InstagramTitle).NotEmpty()
            .WithMessage("Instagram başlık bilgisi girilmelidir.");
        RuleFor(c => c.InstagramIcon).NotEmpty()
            .WithMessage("Instagram ikon bilgisi girilmelidir.");
        RuleFor(c => c.InstagramUrl).NotEmpty()
            .WithMessage("Instagram URL bilgisi girilmelidir.");
        RuleFor(c => c.XTitle).NotEmpty()
            .WithMessage("X başlık bilgisi girilmelidir.");
        RuleFor(c => c.XIcon).NotEmpty()
            .WithMessage("X ikon bilgisi girilmelidir.");
        RuleFor(c => c.XUrl).NotEmpty()
            .WithMessage("X URL bilgisi girilmelidir.");
        RuleFor(c => c.PrintestTitle).NotEmpty()
            .WithMessage("Printest başlık bilgisi girilmelidir.");
        RuleFor(c => c.PrintestIcon).NotEmpty()
            .WithMessage("Printest ikon bilgisi girilmelidir.");
        RuleFor(c => c.PrintestUrl).NotEmpty()
            .WithMessage("Printest URL bilgisi girilmelidir.");
        RuleFor(c => c.LinkedInTitle).NotEmpty()
            .WithMessage("LinkedIn başlık bilgisi girilmelidir.");
        RuleFor(c => c.LinkedInIcon).NotEmpty()
            .WithMessage("LinkedIn ikon bilgisi girilmelidir.");
        RuleFor(c => c.LinkedInUrl).NotEmpty()
            .WithMessage("LinkedIn URL bilgisi girilmelidir.");
        RuleFor(c => c.OpeningDaysInWeekend).NotEmpty()
            .WithMessage("Hafta sonu açık günler girilmelidir.");
        RuleFor(c => c.OpeningHoursInWeekend).NotEmpty()
            .WithMessage("Hafta sonu açık saatler girilmelidir.");
        RuleFor(c => c.OpeningDaysInMidWeek).NotEmpty()
            .WithMessage("Hafta içi açık günler girilmelidir.");
        RuleFor(c => c.OpeningHoursInMidWeek).NotEmpty()
            .WithMessage("Hafta içi açık saatler girilmelidir.");
        RuleFor(c => c.EntityStatus).NotNull()
            .WithMessage("Footer durumu girilmedir.");
    }
}