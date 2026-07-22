using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum LabelType
{
    [Description("Seri No")]
    SerialNumber = 1,
    
    [Description("Enerji")]
    Energy = 2,
    
    [Description("Uyarı")]
    Warning = 3,
    
    [Description("Marka Logosu")]
    BrandLogo = 4,
    
    [Description("Sertifika-CE")]
    Certification = 5
}
