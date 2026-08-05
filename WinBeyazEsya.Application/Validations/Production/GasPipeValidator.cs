using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validations.Production;

public class GasPipeValidator : AbstractValidator<GasPipeDto>
{
    public GasPipeValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.");
            
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Gaz Borusu Adı zorunludur.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim zorunludur.");
    }
}

