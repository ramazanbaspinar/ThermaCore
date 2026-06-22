using FluentValidation;
using ThermaCore.Application.DTOs.Security;

namespace ThermaCore.Application.Validations.Security;

public class RoleDtoValidator : AbstractValidator<RoleDto>
{
    public RoleDtoValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Rol Kodu boş bırakılamaz!")
            .MaximumLength(50).WithMessage("Rol Kodu en fazla 50 karakter olabilir!");

        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Rol Adı boş bırakılamaz!")
            .MaximumLength(100).WithMessage("Rol Adı en fazla 100 karakter olabilir!");
    }
}
