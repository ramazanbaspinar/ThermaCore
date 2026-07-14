using FluentValidation;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validators.Production;

public class ValveValidator : AbstractValidator<ValveDto>
{
    private readonly IRepository<Valve> _valveRepository;

    public ValveValidator(IRepository<Valve> valveRepository)
    {
        _valveRepository = valveRepository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Kod alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Kod alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Valf Adı alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Valf Adı alanı en fazla 100 karakter olabilir.");

        RuleFor(x => x.BaseUnit)
            .NotEmpty().WithMessage("Temel Birim alanı boş bırakılamaz.")
            .MaximumLength(50).WithMessage("Temel Birim alanı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
            
        RuleFor(x => x.ConnectionSize)
            .MaximumLength(100).WithMessage("Bağlantı Ölçüsü en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.TemperatureRange)
            .MaximumLength(100).WithMessage("Sıcaklık Aralığı en fazla 100 karakter olabilir.");
    }
}
