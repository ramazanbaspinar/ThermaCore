using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class MechanicalAndHardwareGroupValidator : AbstractValidator<MechanicalAndHardwareGroupDto>
{
    public MechanicalAndHardwareGroupValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Kod alanı boş geçilemez.");
        RuleFor(x => x.Code).MaximumLength(50).WithMessage("Kod alanı 50 karakterden uzun olamaz.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
        RuleFor(x => x.Name).MaximumLength(150).WithMessage("Ad alanı 150 karakterden uzun olamaz.");

        RuleFor(x => x.BaseUnitId).GreaterThan(0).WithMessage("Lütfen geçerli bir temel birim seçiniz.");
    }
}
