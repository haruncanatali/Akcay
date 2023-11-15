﻿using FluentValidation;

namespace Akcay.Application.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithMessage("Ürün adını giriniz.");
        RuleFor(c => c.Description).NotEmpty()
            .WithMessage("Ürün açıklamasını giriniz.");
        RuleFor(c => c.Price).NotNull()
            .WithMessage("Ürün fiyatını giriniz.");
        RuleFor(c => c.CategoryId).NotNull()
            .WithMessage("Ürün kategorisini giriniz.");
        RuleFor(c => c.Image).NotNull()
            .WithMessage("Ürün fotoğrafını giriniz.");
    }
}