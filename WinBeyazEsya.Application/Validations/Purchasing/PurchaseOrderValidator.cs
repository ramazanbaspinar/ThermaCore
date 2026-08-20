using FluentValidation;
using WinBeyazEsya.Application.DTOs.Purchasing;

namespace WinBeyazEsya.Application.Validations.Purchasing;

public class PurchaseOrderValidator : AbstractValidator<PurchaseOrderDto>
{
    public PurchaseOrderValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Sipariş kodu boş olamaz.");

        RuleFor(x => x.SupplierId)
            .GreaterThan(0).WithMessage("Tedarikçi seçimi zorunludur.");

        RuleFor(x => x.CurrencyId)
            .NotNull().WithMessage("Döviz seçimi zorunludur.")
            .GreaterThan(0).WithMessage("Döviz seçimi zorunludur.");
    }
}
