using FluentValidation;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Application.Validations.Production;

public class SurfaceTypeValidator : AbstractValidator<SurfaceTypeDto>
{
    private readonly IRepository<SurfaceType> _repository;

    public SurfaceTypeValidator(IRepository<SurfaceType> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Kod alanı 50 karakterden uzun olamaz.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code))
            .WithMessage("Bu Kod daha önce kullanılmıştır. Lütfen farklı bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Ad alanı 100 karakterden uzun olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı 500 karakterden uzun olamaz.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !global::System.Linq.Enumerable.Any(_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id));
    }
}

