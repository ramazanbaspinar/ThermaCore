using FluentValidation;
using ThermaCore.Application.DTOs.Production;

namespace ThermaCore.Application.Validations.Production;

public class IgnitionTransformerValidator : AbstractValidator<IgnitionTransformerDto>
{
    public IgnitionTransformerValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Trafo Adı alanı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("Trafo Adı alanı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Temel Birim alanı en fazla 50 karakter olabilir.");
    }
}
