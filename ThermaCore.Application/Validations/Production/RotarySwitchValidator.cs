using FluentValidation;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Validations.Production;

public class RotarySwitchValidator : AbstractValidator<RotarySwitchDto>
{
    public RotarySwitchValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Kod alanı zorunludur.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Anahtar Adı alanı zorunludur.");
        RuleFor(x => x.BaseUnit).NotEmpty().WithMessage("Temel Birim alanı zorunludur.");
    }
}
