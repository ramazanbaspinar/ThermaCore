using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class UserRoleValidator : AbstractValidator<UserRoleDto>
{
    public UserRoleValidator()
    {
        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Role Name cannot be empty.")
            .MaximumLength(50).WithMessage("Role Name can be at most 50 characters long.");
    }
}
