using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class ElectricalElectronicGroupValidator : AbstractValidator<ElectricalElectronicGroupDto>
{
    public ElectricalElectronicGroupValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir.");
            
        RuleFor(x => x.BaseUnitId)
            .NotEmpty().WithMessage("Temel birim seçilmelidir.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }
}
