using FluentValidation;
using WinBeyazEsya.Application.DTOs.Purchasing;

namespace WinBeyazEsya.Application.Validations.Purchasing;

public class PurchaseOrderLineValidator : AbstractValidator<PurchaseOrderLineDto>
{
    public PurchaseOrderLineValidator()
    {
        RuleFor(x => x.MaterialId)
            .GreaterThan(0).WithMessage("Malzeme boş olamaz.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Birim fiyat 0 veya daha büyük olmalıdır.");
    }
}
