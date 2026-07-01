using System.Linq;
using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validations.Production;

public class SheetMetalValidator : AbstractValidator<SheetMetalDto>
{
    private readonly IRepository<SheetMetal> _repository;

    public SheetMetalValidator(IRepository<SheetMetal> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Sac Kodu boş olamaz.")
            .MaximumLength(100).WithMessage("Sac Kodu en fazla 100 karakter olabilir.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Sac Kodu sistemde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Sac Adı boş olamaz.")
            .MaximumLength(100).WithMessage("Sac Adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");



        RuleFor(x => x.QualityStandardId)
            .GreaterThan(0).WithMessage("Lütfen geçerli bir Kalite Standardı seçiniz.");

        RuleFor(x => x.SurfaceTypeId)
            .GreaterThan(0).WithMessage("Lütfen geçerli bir Yüzey Tipi seçiniz.");

        RuleFor(x => x.UnitId)
            .GreaterThan(0).WithMessage("Lütfen geçerli bir Birim seçiniz.");

        RuleFor(x => x.Thickness)
            .GreaterThan(0).WithMessage("Kalınlık 0'dan büyük olmalıdır.");

        RuleFor(x => x.Density)
            .GreaterThan(0).WithMessage("Özkütle 0'dan büyük olmalıdır.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true; // Let NotEmpty handle it
        return !_repository.Find(x => x.Code.ToLower() == code.ToLower() && x.Id != id).Any();
    }
}
