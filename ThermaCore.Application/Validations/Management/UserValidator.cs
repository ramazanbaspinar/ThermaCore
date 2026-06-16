using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be empty.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address cannot be empty.")
            .EmailAddress().WithMessage("Enter a valid email address.");

        RuleFor(x => x.UserRoleId)
            .GreaterThan(0).WithMessage("You must select a valid User Role.");
    }
}
