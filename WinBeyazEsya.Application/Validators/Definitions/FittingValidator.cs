using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class FittingValidator : AbstractValidator<FittingDto>
{
    public FittingValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Ad alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş bırakılamaz.")
            .MaximumLength(10).WithMessage("Temel Birim en fazla 10 karakter olabilir.");
    }
}

