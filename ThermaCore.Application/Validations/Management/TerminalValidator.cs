using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class TerminalValidator : AbstractValidator<TerminalDto>
{
    public TerminalValidator()
    {
        RuleFor(x => x).Must(x => !string.IsNullOrEmpty(x.EthernetMacAddress) || !string.IsNullOrEmpty(x.WifiMacAddress) || !string.IsNullOrEmpty(x.VpnMacAddress))
            .WithMessage("Lütfen en az bir adet MAC Adresi (Ethernet, Wi-Fi veya VPN) giriniz.");
    }
}
