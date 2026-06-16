using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class TerminalValidator : AbstractValidator<TerminalDto>
{
    public TerminalValidator()
    {
        RuleFor(x => x.MacAddress).NotEmpty().WithMessage("MAC Address cannot be empty.");
    }
}
