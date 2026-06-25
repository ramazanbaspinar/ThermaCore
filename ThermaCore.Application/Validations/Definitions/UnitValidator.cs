using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validations.Definitions;

public class UnitValidator : AbstractValidator<UnitDto>
{
    public UnitValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Birim Kodu boş bırakılamaz.")
            .MaximumLength(10).WithMessage("Birim Kodu en fazla 10 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Birim Adı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Birim Adı en fazla 100 karakter olabilir.");
    }
}
