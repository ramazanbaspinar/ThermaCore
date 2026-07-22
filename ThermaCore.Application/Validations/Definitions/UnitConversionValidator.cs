using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validations.Definitions;

public class UnitConversionValidator : AbstractValidator<UnitConversionDto>
{
    public UnitConversionValidator()
    {
        RuleFor(x => x.Multiplier)
            .GreaterThan(0)
            .WithMessage("Çarpan değeri 0'dan büyük olmalıdır.");

        RuleFor(x => x.Divisor)
            .GreaterThan(0)
            .WithMessage("Bölen değeri 0'dan büyük olmalıdır.");
            
        RuleFor(x => x.UnitId)
            .NotEmpty()
            .WithMessage("Birim seçilmelidir.");
    }
}
