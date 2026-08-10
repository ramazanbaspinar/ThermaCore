using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class FinishedGoodValidator : AbstractValidator<FinishedGoodDto>
{
    public FinishedGoodValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Mamül kodu boş geçilemez.")
            .MaximumLength(50).WithMessage("Mamül kodu en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Mamül adı boş geçilemez.")
            .MaximumLength(200).WithMessage("Mamül adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.UnitId)
            .GreaterThan(0).WithMessage("Temel birim seçilmelidir.");

        RuleFor(x => x.GroupType)
            .IsInEnum().WithMessage("Lütfen geçerli bir mamül grubu seçiniz.");
    }
}
