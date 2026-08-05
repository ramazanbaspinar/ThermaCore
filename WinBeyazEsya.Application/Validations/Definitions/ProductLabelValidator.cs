using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validations.Definitions;

public class ProductLabelValidator : AbstractValidator<ProductLabelDto>
{
    public ProductLabelValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Kod alanı boş bırakılamaz.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Etiket Adı boş bırakılamaz.");
        RuleFor(x => x.BaseUnit).NotEmpty().WithMessage("Temel Birim boş bırakılamaz.");
    }
}

