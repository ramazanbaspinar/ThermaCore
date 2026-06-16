using FluentValidation;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Validations.Yonetim;

public class KullaniciRoluValidator : AbstractValidator<KullaniciRoluDto>
{
    public KullaniciRoluValidator()
    {
        RuleFor(x => x.RolAdi)
            .NotEmpty().WithMessage("Rol AdÄ± boÅŸ olamaz.")
            .MaximumLength(50).WithMessage("Rol AdÄ± en fazla 50 karakter olabilir.");
    }
}
