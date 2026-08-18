using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions;

public class WarehouseValidator : AbstractValidator<WarehouseDto>
{
    public WarehouseValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Depo Kodu alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Depo Kodu en fazla 50 karakter olabilir.");
            
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Depo Adı alanı boş bırakılamaz.")
            .MaximumLength(150).WithMessage("Depo Adı en fazla 150 karakter olabilir.");
            
        RuleFor(x => x.AuthorizedPerson)
            .MaximumLength(150).WithMessage("Yetkili Kişi en fazla 150 karakter olabilir.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }
}
