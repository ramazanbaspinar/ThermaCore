using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validations.Definitions;

public class InsulationValidator : AbstractValidator<InsulationDto>
{
    public InsulationValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İzolasyon Adı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("İzolasyon Adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş bırakılamaz.");

        RuleFor(x => x.ThicknessMm)
            .GreaterThan(0).WithMessage("Kalınlık 0'dan büyük olmalıdır.")
            .When(x => x.ThicknessMm.HasValue);
            
        RuleFor(x => x.Density)
            .GreaterThan(0).WithMessage("Yoğunluk 0'dan büyük olmalıdır.")
            .When(x => x.Density.HasValue);
    }
}

