using FluentValidation;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Validators.Production;

public class OvenMotorValidator : AbstractValidator<OvenMotorDto>
{
    private readonly IRepository<OvenMotor> _repository;

    public OvenMotorValidator(IRepository<OvenMotor> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Bu kod zaten kullanılıyor.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Motor Adı alanı boş geçilemez.")
            .MaximumLength(200).WithMessage("Motor Adı alanı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş geçilemez.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}

