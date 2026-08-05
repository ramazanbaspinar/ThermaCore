using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validations.Definitions;

public class WireValidator : AbstractValidator<WireDto>
{
    public WireValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Tel Kodu boş geçilemez.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Tel Adı boş geçilemez.");
        RuleFor(x => x.BaseUnit).NotEmpty().WithMessage("Temel Birim boş geçilemez.");
    }
}

