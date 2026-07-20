using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validators.Definitions;

public class FastenerValidator : AbstractValidator<FastenerDto>
{
    public FastenerValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı zorunludur.")
            .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı zorunludur.");
    }
}
