using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validators.Production;

public class ColorFeatureValidator : AbstractValidator<ColorFeatureDto>
{
    public ColorFeatureValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Renk / Özellik Adı alanı zorunludur.")
            .MaximumLength(200).WithMessage("Renk / Özellik Adı alanı en fazla 200 karakter olabilir.");
    }
}

