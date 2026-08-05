using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validations.Production;

public class MaterialCostValidator : AbstractValidator<MaterialCostDto>
{
    public MaterialCostValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Maliyet Kodu boş geçilemez.")
            .MaximumLength(100).WithMessage("Maliyet Kodu en fazla 100 karakter olabilir.");

        RuleFor(x => x.MaterialType)
            .IsInEnum().WithMessage("Geçerli bir malzeme türü seçiniz.");

        RuleFor(x => x.MaterialId)
            .GreaterThan(0).WithMessage("Geçerli bir malzeme seçiniz.");

        RuleFor(x => x.Cost)
            .GreaterThanOrEqualTo(0).WithMessage("Maliyet değeri 0 veya daha büyük olmalıdır.");

        RuleFor(x => x.CurrencyCode)
            .NotEmpty().WithMessage("Para birimi boş geçilemez.")
            .MaximumLength(5).WithMessage("Para birimi kodu en fazla 5 karakter olabilir.");
    }
}

