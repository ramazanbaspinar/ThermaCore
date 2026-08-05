using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validations.Production;

public class EmayeValidator : AbstractValidator<EmayeDto>
{
    public EmayeValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Kod alanı boş geçilemez.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Emaye Adı alanı boş geçilemez.");
        RuleFor(x => x.BaseUnit).NotEmpty().WithMessage("Temel Birim alanı boş geçilemez.");
    }
}

