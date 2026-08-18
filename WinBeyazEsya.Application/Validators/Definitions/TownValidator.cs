using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class TownValidator : AbstractValidator<TownDto>
{
    public TownValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(51).WithMessage("Ad alanı en fazla 51 karakter olabilir.");
    }
}
