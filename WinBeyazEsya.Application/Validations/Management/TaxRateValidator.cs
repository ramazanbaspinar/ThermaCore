using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using System.Linq;

namespace WinBeyazEsya.Application.Validations.Management;

public class TaxRateValidator : AbstractValidator<TaxRateDto>
{
    private readonly IRepository<TaxRate> _repository;

    public TaxRateValidator(IRepository<TaxRate> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Vergi kodu boş olamaz.")
            .MaximumLength(50).WithMessage("Vergi kodu en fazla 50 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz vergi kodu sistemde zaten kayıtlı. Lütfen farklı bir kod giriniz.");

        RuleFor(x => x.Rate)
            .GreaterThanOrEqualTo(0).WithMessage("Vergi oranı 0'dan küçük olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrEmpty(code)) return true;
        return !_repository.Find(x => x.Code == code && x.Id != id).Any();
    }
}

