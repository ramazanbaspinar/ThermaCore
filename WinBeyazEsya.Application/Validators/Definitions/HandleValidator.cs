using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class HandleValidator : AbstractValidator<HandleDto>
{
    public HandleValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("Ad alanı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Birim alanı boş bırakılamaz.")
            .MaximumLength(20).WithMessage("Birim alanı en fazla 20 karakter olabilir.");
            
        // Not: IsCodeUnique kontrolü BaseManager.CheckBusinessRules üzerinden global olarak yapılmaktadır.
    }
}

