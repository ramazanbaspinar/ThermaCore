using FluentValidation;
using WinBeyazEsya.Application.DTOs.Purchasing;

namespace WinBeyazEsya.Application.Validations.Purchasing
{
    public class PurchaseReceiptLineDtoValidator : AbstractValidator<PurchaseReceiptLineDto>
    {
        public PurchaseReceiptLineDtoValidator()
        {
            RuleFor(x => x.MaterialId)
                .GreaterThan(0).WithMessage("Satırda Malzeme seçimi zorunludur.");

            RuleFor(x => x.UnitId)
                .GreaterThan(0).WithMessage("Satırda Birim seçimi zorunludur.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Satır Miktarı 0'dan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Satır Birim Fiyatı 0'dan küçük olamaz.");

            RuleFor(x => x.WarehouseId)
                .NotEmpty().WithMessage("İrsaliye satırlarında Teslimat Deposu boş bırakılamaz!");
        }
    }
}
