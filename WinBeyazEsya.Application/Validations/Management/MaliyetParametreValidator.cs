using FluentValidation;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Validations.Management;

public class MaliyetParametreValidator : AbstractValidator<MaliyetParametreDto>
{
    public MaliyetParametreValidator()
    {
        RuleFor(x => x.MaturityDifferenceRate)
            .GreaterThanOrEqualTo(0).WithMessage("Vade farkı oranı 0'dan küçük olamaz.");

        RuleFor(x => x.WastageRate)
            .GreaterThanOrEqualTo(0).WithMessage("Fire oranı 0'dan küçük olamaz.");

        RuleFor(x => x.OvenAvgMonthlyProduction).GreaterThanOrEqualTo(0).WithMessage("Fırın aylık ortalama üretim adedi 0'dan küçük olamaz.");
        RuleFor(x => x.CookerAvgMonthlyProduction).GreaterThanOrEqualTo(0).WithMessage("Ocak aylık ortalama üretim adedi 0'dan küçük olamaz.");
        RuleFor(x => x.BuiltInAvgMonthlyProduction).GreaterThanOrEqualTo(0).WithMessage("Ankastre aylık ortalama üretim adedi 0'dan küçük olamaz.");
        RuleFor(x => x.FreestandingAvgMonthlyProduction).GreaterThanOrEqualTo(0).WithMessage("Solo aylık ortalama üretim adedi 0'dan küçük olamaz.");
        RuleFor(x => x.OtherAvgMonthlyProduction).GreaterThanOrEqualTo(0).WithMessage("Diğer aylık ortalama üretim adedi 0'dan küçük olamaz.");
    }
}

