using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class MetalSheetGroupValidator : AbstractValidator<MetalSheetGroupDto>
{
    public MetalSheetGroupValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(150).WithMessage("Ad alanı en fazla 150 karakter olabilir.");
            
        RuleFor(x => x.BaseUnitId)
            .NotEmpty().WithMessage("Temel birim seçilmelidir.");
            
        RuleFor(x => x.Width)
            .GreaterThan(0).WithMessage("En değeri sıfırdan büyük olmalıdır.");
            
        RuleFor(x => x.Length)
            .GreaterThan(0).WithMessage("Boy değeri sıfırdan büyük olmalıdır.");
            
        RuleFor(x => x.Thickness)
            .GreaterThan(0).WithMessage("Kalınlık değeri sıfırdan büyük olmalıdır.");
            
        RuleFor(x => x.SurfaceType)
            .MaximumLength(100).WithMessage("Yüzey Tipi en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.QualityCode)
            .MaximumLength(100).WithMessage("Kalite Kodu en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }
}
