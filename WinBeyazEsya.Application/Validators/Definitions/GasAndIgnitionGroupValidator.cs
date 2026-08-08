using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class GasAndIgnitionGroupValidator : AbstractValidator<GasAndIgnitionGroupDto>
{
    public GasAndIgnitionGroupValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Gaz ve Ateşleme Grubu adı boş geçilemez.")
            .MaximumLength(150).WithMessage("Gaz ve Ateşleme Grubu adı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnitId)
            .GreaterThan(0).WithMessage("Temel birim seçilmelidir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }
}
