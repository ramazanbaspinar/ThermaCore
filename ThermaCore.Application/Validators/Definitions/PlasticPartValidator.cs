using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;

namespace ThermaCore.Application.Validators.Definitions
{
    public class PlasticPartValidator : AbstractValidator<PlasticPartDto>
    {
        public PlasticPartValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Kod alanı boş geçilemez.")
                .MaximumLength(100).WithMessage("Kod en fazla 100 karakter olabilir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Plastik Parça Adı boş geçilemez.")
                .MaximumLength(100).WithMessage("Plastik Parça Adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.BaseUnit)
                .NotEmpty().WithMessage("Temel Birim boş geçilemez.")
                .MaximumLength(50).WithMessage("Temel Birim en fazla 50 karakter olabilir.");
        }
    }
}
