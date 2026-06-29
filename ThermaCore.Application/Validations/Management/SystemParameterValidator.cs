using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class SystemParameterValidator : AbstractValidator<SystemParameterDto>
{
    public SystemParameterValidator()
    {
        RuleFor(x => x.CompanyName)
            .MaximumLength(100).WithMessage("Firma ünvanı en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.DefaultWastageRate)
            .GreaterThanOrEqualTo(0).WithMessage("Fire oranı 0'dan küçük olamaz.");
    }
}
