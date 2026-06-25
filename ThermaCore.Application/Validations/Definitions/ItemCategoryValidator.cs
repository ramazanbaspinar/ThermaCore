using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validations.Definitions;

public class ItemCategoryValidator : AbstractValidator<ItemCategoryDto>
{
    public ItemCategoryValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kategori Kodu boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kategori Kodu en fazla 50 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori Adı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("Kategori Adı en fazla 200 karakter olabilir.");
    }
}
