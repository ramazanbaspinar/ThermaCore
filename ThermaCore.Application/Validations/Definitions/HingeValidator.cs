using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Validations.Definitions;

public class HingeValidator : AbstractValidator<HingeDto>
{
    private readonly IRepository<Hinge> _repository;

    public HingeValidator(IRepository<Hinge> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Menteşe Kodu boş geçilemez.")
            .MaximumLength(100).WithMessage("Menteşe Kodu en fazla 100 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Menteşe Kodu sistemde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");
            
        RuleFor(x => x.Name).NotEmpty().WithMessage("Menteşe Adı boş geçilemez.");
        RuleFor(x => x.BaseUnit).NotEmpty().WithMessage("Temel Birim boş geçilemez.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true; // Let NotEmpty handle it
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id).Any();
    }
}
