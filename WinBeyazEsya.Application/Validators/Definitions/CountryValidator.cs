using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class CountryValidator : AbstractValidator<CountryDto>
{
    public CountryValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir.");
    }
}
