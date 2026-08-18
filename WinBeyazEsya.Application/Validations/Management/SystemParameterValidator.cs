using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class SystemParameterValidator : AbstractValidator<SystemParameterDto>
{
    public SystemParameterValidator()
    {
        RuleFor(x => x.CompanyName)
            .MaximumLength(100).WithMessage("Firma ünvanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.DefaultWastageRate)
            .GreaterThanOrEqualTo(0).WithMessage("Fire oranı 0'dan küçük olamaz.");

        RuleFor(x => x.CompanyBarcodePrefix)
            .Matches("^[0-9]*$").WithMessage("Şirket Barkod Öneki sadece rakamlardan oluşmalıdır.");
    }
}

