using FluentValidation;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Validators.Production;

public class GasValveValidator : AbstractValidator<GasValveDto>
{
    private readonly IRepository<GasValve> _repository;

    public GasValveValidator(IRepository<GasValve> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
            .MaximumLength(50).WithMessage("Kod alanı en fazla 50 karakter olabilir.")
            .Must(BeUniqueCode).WithMessage("Bu kod zaten kullanılıyor.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Gaz Musluğu Adı alanı boş geçilemez.")
            .MaximumLength(200).WithMessage("Gaz Musluğu Adı alanı en fazla 200 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim boş geçilemez.");
            
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
    }

    private bool BeUniqueCode(GasValveDto dto, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != dto.Id).Any();
    }
}

