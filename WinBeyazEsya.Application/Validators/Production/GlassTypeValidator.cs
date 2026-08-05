using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validators.Production;

public class GlassTypeValidator : AbstractValidator<GlassTypeDto>
{
    public GlassTypeValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Cam Tipi Adı alanı zorunludur.")
            .MaximumLength(200).WithMessage("Cam Tipi Adı alanı en fazla 200 karakter olabilir.");
    }
}

