using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;

namespace ThermaCore.Application.Validations.Definitions
{
    public class GeneralExpenseValidator : AbstractValidator<GeneralExpenseDto>
    {
        public GeneralExpenseValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Genel Gider kodu boş olamaz.")
                .MaximumLength(50).WithMessage("Genel Gider kodu en fazla 50 karakter olabilir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Genel Gider adı boş olamaz.")
                .MaximumLength(100).WithMessage("Genel Gider adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Maliyet 0'dan küçük olamaz.");
        }
    }
}
