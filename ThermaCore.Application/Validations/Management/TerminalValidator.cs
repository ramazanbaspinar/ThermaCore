using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class TerminalValidator : AbstractValidator<TerminalDto>
{
    public TerminalValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Terminal Kodu boş bırakılamaz.");
        RuleFor(x => x.DeviceName).NotEmpty().WithMessage("Cihaz Adı boş bırakılamaz.");
        RuleFor(x => x.HardwareId).NotEmpty().WithMessage("Lütfen Donanım Kimliği (HWID) giriniz.");
    }
}
