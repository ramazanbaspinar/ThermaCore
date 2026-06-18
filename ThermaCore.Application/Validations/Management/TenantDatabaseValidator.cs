using FluentValidation;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using System.Linq;

namespace ThermaCore.Application.Validations.Management;

public class TenantDatabaseValidator : AbstractValidator<TenantDatabaseDto>
{
    private readonly IMasterRepository<TenantDatabase> _repository;

    public TenantDatabaseValidator(IMasterRepository<TenantDatabase> repository)
    {
        _repository = repository;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Lütfen Şirket Kodu giriniz.")
            .Matches(@"^\S+$").WithMessage("Kod alanı boşluk içeremez.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Şirket Kodu sistemde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");

        RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Lütfen Şirket Adı giriniz.");
        RuleFor(x => x.DatabaseName).NotEmpty().WithMessage("Lütfen Veritabanı Adı giriniz.");
        RuleFor(x => x.Server).NotEmpty().WithMessage("Lütfen Sunucu (Server) bilgisi giriniz.");

        When(x => x.AuthType != AuthenticationType.Windows, () =>
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen SQL Kullanıcı Adı giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen SQL Şifresi giriniz.");
        });
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrEmpty(code)) return true; // Handled by NotEmpty
        return !_repository.Find(x => x.Code == code && x.Id != id).Any();
    }
}
