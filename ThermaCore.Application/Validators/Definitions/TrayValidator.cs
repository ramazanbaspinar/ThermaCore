using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validators.Definitions;

public class TrayValidator : AbstractValidator<TrayDto>
{
    public TrayValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tepsi Adı alanı boş geçilemez.")
            .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı boş geçilemez.")
            .MaximumLength(20).WithMessage("Temel Birim en fazla 20 karakter olabilir.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }
}
