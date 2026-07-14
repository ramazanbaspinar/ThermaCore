using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validators.Production;

public class InjectorValidator : AbstractValidator<InjectorDto>
{
    private readonly IRepository<Injector> _repository;

    public InjectorValidator(IRepository<Injector> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Bu kod zaten kullanımda.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Enjektör adı boş bırakılamaz.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel birim boş bırakılamaz.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id).Any();
    }
}
