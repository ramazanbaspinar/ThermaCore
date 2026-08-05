using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validations.Production;

public class ThermostatValidator : AbstractValidator<ThermostatDto>
{
    public ThermostatValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş olamaz.")
            .MaximumLength(50).WithMessage("Kod en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Termostat Adı boş olamaz.")
            .MaximumLength(200).WithMessage("Termostat Adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş olamaz.");
    }
}

