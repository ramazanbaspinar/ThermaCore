using FluentValidation;
using System.Linq;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Production;

namespace ThermaCore.Application.Validators.Production
{
    public class BurnerValidator : AbstractValidator<BurnerDto>
    {
        private readonly IRepository<Burner> _burnerRepository;

        public BurnerValidator(IRepository<Burner> burnerRepository)
        {
            _burnerRepository = burnerRepository;

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Bek Grubu kodu boş bırakılamaz.")
                .Must(BeUniqueCode).WithMessage("Bu kod ile daha önce kaydedilmiş bir Bek Grubu bulunmaktadır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bek Grubu adı boş bırakılamaz.");

            RuleFor(x => x.BaseUnit)
                .NotEmpty().WithMessage("Temel birim seçilmelidir.");

        }

        private bool BeUniqueCode(BurnerDto dto, string code)
        {
            return !_burnerRepository.Find(x => x.Code == code && x.Id != dto.Id).Any();
        }
    }
}
