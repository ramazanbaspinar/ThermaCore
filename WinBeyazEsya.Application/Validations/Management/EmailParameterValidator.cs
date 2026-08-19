using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class EmailParameterValidator : AbstractValidator<EmailParameterDto>
{
    public EmailParameterValidator()
    {
        RuleFor(x => x.SmtpServer)
            .NotEmpty().WithMessage("SMTP Sunucusu boş geçilemez.")
            .MaximumLength(150).WithMessage("SMTP Sunucusu en fazla 150 karakter olabilir.");

        RuleFor(x => x.Port)
            .GreaterThan(0).WithMessage("Port numarası 0'dan büyük olmalıdır.");

        RuleFor(x => x.SenderName)
            .NotEmpty().WithMessage("Gönderici adı boş geçilemez.")
            .MaximumLength(150).WithMessage("Gönderici adı en fazla 150 karakter olabilir.");

        RuleFor(x => x.SenderEmail)
            .NotEmpty().WithMessage("Gönderici e-posta adresi boş geçilemez.")
            .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.")
            .MaximumLength(150).WithMessage("Gönderici e-posta adresi en fazla 150 karakter olabilir.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parola boş geçilemez.")
            .MaximumLength(250).WithMessage("Parola en fazla 250 karakter olabilir.");
    }
}
