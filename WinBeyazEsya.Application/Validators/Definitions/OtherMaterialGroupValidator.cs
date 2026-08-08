using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class OtherMaterialGroupValidator : AbstractValidator<OtherMaterialGroupDto>
{
    public OtherMaterialGroupValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Malzeme Adı boş geçilemez.")
            .MaximumLength(150).WithMessage("Malzeme Adı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnitId)
            .GreaterThan(0).WithMessage("Temel Birim seçilmelidir.");
    }
}
