using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using System.Linq;

namespace ThermaCore.Application.Validations.Definitions;

public class ItemCategoryValidator : AbstractValidator<ItemCategoryDto>
{
    private readonly IItemCategoryRepository _repository;

    public ItemCategoryValidator(IItemCategoryRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kategori Kodu boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kategori Kodu en fazla 50 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code))
            .WithMessage("Girdiğiniz Kategori Kodu sistemde zaten kayıtlı. Lütfen farklı bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori Adı boş bırakılamaz.")
            .MaximumLength(200).WithMessage("Kategori Adı en fazla 200 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code == code && x.Id != id).Any();
    }
}
