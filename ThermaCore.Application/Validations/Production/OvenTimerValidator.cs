using FluentValidation;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Validations.Production;

public class OvenTimerValidator : AbstractValidator<OvenTimerDto>
{
    public OvenTimerValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Zamanlayıcı (Timer) Adı alanı zorunludur.")
            .MaximumLength(150).WithMessage("Zamanlayıcı Adı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı zorunludur.");
    }
}
