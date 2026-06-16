using FluentValidation;
using ThermaCore.Application.DTOs.Yonetim;

namespace ThermaCore.Application.Validations.Yonetim;

public class KullaniciValidator : AbstractValidator<KullaniciDto>
{
    public KullaniciValidator()
    {
        RuleFor(x => x.Adi).NotEmpty().WithMessage("KullanÄ±cÄ± AdÄ± boÅŸ olamaz.");
        RuleFor(x => x.Soyadi).NotEmpty().WithMessage("KullanÄ±cÄ± SoyadÄ± boÅŸ olamaz.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta adresi boÅŸ olamaz.")
            .EmailAddress().WithMessage("GeÃ§erli bir e-posta adresi giriniz.");

        RuleFor(x => x.KullaniciRoluId)
            .GreaterThan(0).WithMessage("GeÃ§erli bir KullanÄ±cÄ± RolÃ¼ seÃ§melisiniz.");
    }
}
