using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validations.Production;

public class HeatingElementValidator : AbstractValidator<HeatingElementDto>
{
    public HeatingElementValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Rezistans Adı boş geçilemez.")
            .MaximumLength(150).WithMessage("Rezistans Adı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş geçilemez.")
            .MaximumLength(20).WithMessage("Temel Birim en fazla 20 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }
}

