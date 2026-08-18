using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;

namespace WinBeyazEsya.Application.Validations.Definitions;

public class UnitValidator : AbstractValidator<UnitDto>
{
    private readonly IUnitRepository _repository;

    public UnitValidator(IUnitRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Birim Kodu boş bırakılamaz.")
            .MaximumLength(10).WithMessage("Birim Kodu en fazla 10 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code))
            .WithMessage("Girdiğiniz Birim Kodu sistemde zaten kayıtlı. Lütfen farklı bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Birim Adı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Birim Adı en fazla 100 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code == code && x.Id != id).Any();
    }
}

