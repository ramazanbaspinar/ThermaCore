using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum ManualType
{
    [Description("Kullanma Kılavuzu")]
    UserGuide = 1,
    [Description("Garanti Belgesi")]
    WarrantyCard = 2,
    [Description("Enerji Etiketi")]
    EnergyLabel = 3,
    [Description("Kurulum Şablonu")]
    InstallationTemplate = 4,
    [Description("Uyarı Föyü")]
    WarningSheet = 5
}

