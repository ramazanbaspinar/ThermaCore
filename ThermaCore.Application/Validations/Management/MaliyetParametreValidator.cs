using FluentValidation;
using ThermaCore.Application.DTOs.Management;

namespace ThermaCore.Application.Validations.Management;

public class MaliyetParametreValidator : AbstractValidator<MaliyetParametreDto>
{
    public MaliyetParametreValidator()
    {
        RuleFor(x => x.MaturityDifferenceRate)
            .GreaterThanOrEqualTo(0).WithMessage("Vade farkı oranı 0'dan küçük olamaz.");
            
        RuleFor(x => x.WastageRate)
            .GreaterThanOrEqualTo(0).WithMessage("Fire oranı 0'dan küçük olamaz.");
            
        RuleFor(x => x.AverageProductionValue)
            .GreaterThanOrEqualTo(0).WithMessage("Ortalama üretim değeri 0'dan küçük olamaz.");
    }
}
