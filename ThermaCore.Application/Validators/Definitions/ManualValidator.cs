using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validators.Definitions;

public class ManualValidator : AbstractValidator<ManualDto>
{
    public ManualValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Matbaa (Kılavuz) Adı zorunludur.")
            .MaximumLength(100).WithMessage("Matbaa (Kılavuz) Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı zorunludur.");
    }
}
