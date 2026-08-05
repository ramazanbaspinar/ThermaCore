using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validations.Definitions;

public class GasketValidator : AbstractValidator<GasketDto>
{
    public GasketValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Conta Adı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("Conta Adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş bırakılamaz.");
            
        RuleFor(x => x.LengthMm)
            .GreaterThan(0).WithMessage("Uzunluk 0'dan büyük olmalıdır.")
            .When(x => x.LengthMm.HasValue);
    }
}

