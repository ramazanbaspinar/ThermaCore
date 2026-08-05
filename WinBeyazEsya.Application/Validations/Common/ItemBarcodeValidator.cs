using FluentValidation;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Common;
using System.Linq;

namespace WinBeyazEsya.Application.Validations.Common;

public class ItemBarcodeValidator : AbstractValidator<ItemBarcodeDto>
{
    private readonly IRepository<ItemBarcode> _repository;

    public ItemBarcodeValidator(IRepository<ItemBarcode> repository)
    {
        _repository = repository;

        RuleFor(x => x.BarcodeValue)
            .NotEmpty().WithMessage("Barkod Değeri boş olamaz.")
            .MaximumLength(100).WithMessage("Barkod Değeri en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

        RuleFor(x => x.RecordId)
            .GreaterThan(0).WithMessage("Geçerli bir kayıt ID'si bulunamadı.");

        RuleFor(x => x.IsPrimary)
            .Must((dto, isPrimary) => IsOnlyOnePrimary(dto)).WithMessage("Bu kayıt için zaten bir Ana Barkod tanımlanmış. Lütfen sadece bir tane varsayılan barkod seçin.");

        RuleFor(x => x.QuantityPerUnit)
            .GreaterThan(0).WithMessage("Birim miktarı 0'dan büyük olmalıdır.");
    }

    private bool IsOnlyOnePrimary(ItemBarcodeDto dto)
    {
        if (!dto.IsPrimary) return true;

        var existingPrimary = _repository.Find(x => x.RecordId == dto.RecordId && x.ModuleType == dto.ModuleType && x.IsPrimary && x.Id != dto.Id).FirstOrDefault();
        return existingPrimary == null;
    }
}

