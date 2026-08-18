using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Kullanıcı adı (Kod) boş bırakılamaz!");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email adresi boş geçilemez.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.UserRoleId)
            .GreaterThan(0).WithMessage("Kullanıcı için geçerli bir rol seçilmelidir.");
    }
}

