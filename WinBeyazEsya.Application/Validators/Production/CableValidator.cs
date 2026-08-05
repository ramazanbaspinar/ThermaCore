using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;

namespace WinBeyazEsya.Application.Validators.Production;

public class CableValidator : AbstractValidator<CableDto>
{
    public CableValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kablo adı boş bırakılamaz.")
            .MaximumLength(150).WithMessage("Kablo adı en fazla 150 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel birim seçilmelidir.");
    }
}

