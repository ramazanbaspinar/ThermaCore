using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using System.Linq;

namespace ThermaCore.Application.Validations.Management;

public class TerminalValidator : AbstractValidator<TerminalDto>
{
    private readonly IMasterRepository<Terminal> _repository;

    public TerminalValidator(IMasterRepository<Terminal> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Terminal Kodu boş bırakılamaz.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code))
            .WithMessage("Girdiğiniz Terminal Kodu sistemde zaten kayıtlı. Lütfen farklı bir kod giriniz.");

        RuleFor(x => x.HardwareId).NotEmpty().WithMessage("Lütfen Donanım Kimliği (HWID) giriniz.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return true;
        return !_repository.Find(x => x.Code == code && x.Id != id).Any();
    }
}
