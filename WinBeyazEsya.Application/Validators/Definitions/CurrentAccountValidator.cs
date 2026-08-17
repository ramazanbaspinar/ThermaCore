using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class CurrentAccountValidator : AbstractValidator<CurrentAccountDto>
{
    public CurrentAccountValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");
            
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir.");
        RuleFor(x => x.CardType)
            .NotEmpty().WithMessage("Cari Tipi seçimi zorunludur.");

        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("Ülke seçimi zorunludur.");

        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("İl seçimi zorunludur.");

        RuleFor(x => x.TownId)
            .NotEmpty().WithMessage("İlçe seçimi zorunludur.");
    }
}
