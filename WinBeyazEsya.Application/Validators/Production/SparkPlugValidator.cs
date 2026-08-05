using FluentValidation;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Validators.Production;

public class SparkPlugValidator : AbstractValidator<SparkPlugDto>
{
    private readonly IRepository<SparkPlug> _repository;

    public SparkPlugValidator(IRepository<SparkPlug> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Çakmak Kodu boş olamaz.")
            .MaximumLength(100).WithMessage("Çakmak Kodu en fazla 100 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Çakmak Kodu sistemde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Çakmak Adı boş olamaz.")
            .MaximumLength(100).WithMessage("Çakmak Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş olamaz.")
            .MaximumLength(50).WithMessage("Temel Birim en fazla 50 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true; // Let NotEmpty handle it
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id).Any();
    }
}

