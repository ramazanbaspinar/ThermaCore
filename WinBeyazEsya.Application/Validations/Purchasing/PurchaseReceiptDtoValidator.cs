using FluentValidation;
using WinBeyazEsya.Application.DTOs.Purchasing;
using System.Linq;

namespace WinBeyazEsya.Application.Validations.Purchasing
{
    public class PurchaseReceiptDtoValidator : AbstractValidator<PurchaseReceiptDto>
    {
        public PurchaseReceiptDtoValidator()
        {
            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Lütfen bir Tedarikçi (Cari) seçiniz.");
                
            RuleFor(x => x.CurrencyCode)
                .NotEmpty().WithMessage("Lütfen Döviz Türü seçiniz.");

            RuleFor(x => x.Lines)
                .Must(lines => lines != null && lines.Any()).WithMessage("İrsaliye en az bir satır (kalem) içermelidir.");
                
            RuleForEach(x => x.Lines).SetValidator(new PurchaseReceiptLineDtoValidator());
        }
    }
}
