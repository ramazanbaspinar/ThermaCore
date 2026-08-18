using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class BranchValidator : AbstractValidator<BranchDto>
{
    private readonly IMasterRepository<Branch> _repository;
    private readonly ICurrentTenantService _currentTenantService;

    public BranchValidator(IMasterRepository<Branch> repository, ICurrentTenantService currentTenantService)
    {
        _repository = repository;
        _currentTenantService = currentTenantService;

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Lütfen Fabrika Kodu giriniz.")
            .Matches(@"^\S+$").WithMessage("Kod alanı boşluk içeremez.")
            .Must((dto, code) => IsCodeUnique(dto.Id, code)).WithMessage("Girdiğiniz Fabrika Kodu bu şirket içerisinde zaten kullanılmaktadır. Lütfen benzersiz bir kod giriniz.");

        RuleFor(x => x.BranchName).NotEmpty().WithMessage("Lütfen Fabrika Adı giriniz.");
    }

    private bool IsCodeUnique(long id, string code)
    {
        if (string.IsNullOrEmpty(code)) return true;
        return !_repository.Find(x => x.Code == code && x.TenantDatabaseId == _currentTenantService.TenantId && x.Id != id).Any();
    }
}

