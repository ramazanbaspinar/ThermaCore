using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validations.Production;

public class QualityStandardValidator : AbstractValidator<QualityStandardDto>
{
    private readonly IRepository<QualityStandard> _repository;

    public QualityStandardValidator(IRepository<QualityStandard> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kalite Standart Kodu boş olamaz.")
            .MaximumLength(50).WithMessage("Kalite Standart Kodu en fazla 50 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Kod sistemde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kalite Standart Adı boş olamaz.")
            .MaximumLength(100).WithMessage("Kalite Standart Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.MaterialGroup)
            .IsInEnum().WithMessage("Lütfen geçerli bir Malzeme Türü seçiniz.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id).Any();
    }
}
