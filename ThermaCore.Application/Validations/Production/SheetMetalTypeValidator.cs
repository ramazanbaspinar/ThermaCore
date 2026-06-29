using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validations.Production;

public class SheetMetalTypeValidator : AbstractValidator<SheetMetalTypeDto>
{
    private readonly IRepository<SheetMetalType> _repository;

    public SheetMetalTypeValidator(IRepository<SheetMetalType> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Sac Cinsi Kodu boş olamaz.")
            .MaximumLength(50).WithMessage("Sac Cinsi Kodu en fazla 50 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Sac Cinsi Kodu sistemde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Sac Cinsi Adı boş olamaz.")
            .MaximumLength(100).WithMessage("Sac Cinsi Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true; // Let NotEmpty handle it

        var exists = _repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id).Any();
        return !exists;
    }
}
