using FluentValidation;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Validations.Production;

public class ScrewValidator : AbstractValidator<ScrewDto>
{
    public ScrewValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Kod alanı boş geçilemez.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Screw Adı alanı boş geçilemez.");
        RuleFor(x => x.BaseUnit).NotEmpty().WithMessage("Temel Birim alanı boş geçilemez.");
    }
}
