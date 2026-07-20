using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validators.Definitions;

public class PackagingMaterialValidator : AbstractValidator<PackagingMaterialDto>
{
    public PackagingMaterialValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .NotNull().WithMessage("Kod alanı zorunludur.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ambalaj Malzemesi Adı zorunludur.")
            .NotNull().WithMessage("Ambalaj Malzemesi Adı zorunludur.")
            .MaximumLength(100).WithMessage("Ambalaj Malzemesi Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı zorunludur.")
            .NotNull().WithMessage("Temel Birim alanı zorunludur.");
    }
}
