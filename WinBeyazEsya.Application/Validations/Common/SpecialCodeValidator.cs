using FluentValidation;
using WinBeyazEsya.Application.DTOs.Common;

namespace WinBeyazEsya.Application.Validations.Common;

public class SpecialCodeValidator : AbstractValidator<SpecialCodeDto>
{
    public SpecialCodeValidator()
    {
        RuleFor(x => x.EntityType)
            .NotEmpty().WithMessage("Entity Type boş olamaz.")
            .MaximumLength(50).WithMessage("Entity Type en fazla 50 karakter olabilir.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod boş olamaz.")
            .MaximumLength(50).WithMessage("Kod en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Özel Kod Adı boş geçilemez")
            .MaximumLength(100).WithMessage("Özel Kod Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olabilir.");
    }
}

