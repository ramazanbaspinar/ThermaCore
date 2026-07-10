using FluentValidation;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Validators.Production;

public class HotplateValidator : AbstractValidator<HotplateDto>
{
    public HotplateValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Pleyt Adı alanı boş geçilemez.")
            .MaximumLength(200).WithMessage("Pleyt Adı alanı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş geçilemez.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }
}
