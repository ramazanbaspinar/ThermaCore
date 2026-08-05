using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Production;
using System.Linq;

namespace WinBeyazEsya.Application.ValidationRules.Production;

public class OvenLampValidator : AbstractValidator<OvenLampDto>
{
    private readonly IRepository<OvenLamp> _repository;

    public OvenLampValidator(IRepository<OvenLamp> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Lamba Kodu boş geçilemez.")
            .MaximumLength(50).WithMessage("Lamba Kodu en fazla 50 karakter olabilir.")
            .Must(BeUniqueCode).WithMessage("Bu Lamba Kodu daha önce kullanılmıştır. Lütfen farklı bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Lamba Adı boş geçilemez.")
            .MaximumLength(250).WithMessage("Lamba Adı en fazla 250 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş geçilemez.")
            .MaximumLength(50).WithMessage("Temel Birim en fazla 50 karakter olabilir.");

        RuleFor(x => x.SocketType)
            .MaximumLength(100).WithMessage("Duy Tipi en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }

    private bool BeUniqueCode(OvenLampDto dto, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != dto.Id).Any();
    }
}

