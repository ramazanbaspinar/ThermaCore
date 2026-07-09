using FluentValidation;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Validators.Production;

public class KnobValidator : AbstractValidator<KnobDto>
{
    public KnobValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Düğme Adı alanı zorunludur.")
            .MaximumLength(200).WithMessage("Düğme Adı alanı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı zorunludur.")
            .MaximumLength(20).WithMessage("Temel Birim alanı en fazla 20 karakter olabilir.");
    }
}
