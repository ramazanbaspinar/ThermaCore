using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class CodeTemplateValidator : AbstractValidator<CodeTemplateDto>
{
    public CodeTemplateValidator()
    {
        RuleFor(x => x.CodePrefix)
            .NotEmpty().WithMessage("Kod Öneki boş olamaz.")
            .MaximumLength(100).WithMessage("Kod Öneki en fazla 100 karakter olabilir.");

        RuleFor(x => x.CodeSuffix)
            .MaximumLength(100).WithMessage("Kod Soneki en fazla 100 karakter olabilir.");

        RuleFor(x => x.NumericLength)
            .GreaterThan((byte)0).WithMessage("Sayısal Uzunluk 0'dan büyük olmalıdır.");

        RuleFor(x => x.StartNumber)
            .GreaterThanOrEqualTo(0).WithMessage("Başlangıç Numarası 0 veya daha büyük olmalıdır.");
            
        RuleFor(x => x.Module)
            .IsInEnum().WithMessage("Geçerli bir modül seçiniz.");
    }
}

