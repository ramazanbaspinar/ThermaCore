using FluentValidation;
using System.Linq;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validators.Production;

public class ThermocoupleValidator : AbstractValidator<ThermocoupleDto>
{
    private readonly IRepository<Thermocouple> _repository;

    public ThermocoupleValidator(IRepository<Thermocouple> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı zorunludur.")
            .Must(IsUniqueCode).WithMessage("Bu kod zaten kullanılıyor.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Termokupl (Emniyet) adı alanı zorunludur.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel birim alanı zorunludur.");
    }

    private bool IsUniqueCode(ThermocoupleDto dto, string code)
    {
        var existing = _repository.Find(x => x.Code == code).FirstOrDefault();
        if (existing == null)
            return true;

        return existing.Id == dto.Id;
    }
}
