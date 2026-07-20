using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validators.Definitions;

public class LockValidator : AbstractValidator<LockDto>
{
    public LockValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı 50 karakterden uzun olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş geçilemez.")
            .MaximumLength(200).WithMessage("Ad alanı 200 karakterden uzun olamaz.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Temel Birim alanı 50 karakterden uzun olamaz.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı 500 karakterden uzun olamaz.");
    }
}
