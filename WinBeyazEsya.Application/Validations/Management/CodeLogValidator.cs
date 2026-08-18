using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class CodeLogValidator : AbstractValidator<CodeLogDto>
{
    public CodeLogValidator()
    {
        RuleFor(x => x.Module)
            .IsInEnum().WithMessage("Geçerli bir modül seçiniz.");

        RuleFor(x => x.CompanyCode)
            .MaximumLength(100).WithMessage("Firma Kodu en fazla 100 karakter olabilir.");

        RuleFor(x => x.DateKey)
            .MaximumLength(100).WithMessage("Tarih Anahtarı en fazla 100 karakter olabilir.");

        RuleFor(x => x.LastCodeValue)
            .GreaterThanOrEqualTo(0).WithMessage("Son Kod Değeri 0 veya daha büyük olmalıdır.");

        RuleFor(x => x.BranchName)
            .MaximumLength(100).WithMessage("Şube Adı en fazla 100 karakter olabilir.");
    }
}

