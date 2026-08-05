using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum GridType
{
    [Description("Düz Standart")]
    Flat = 1,
    
    [Description("Teleskopik Uyumlu")]
    Telescopic = 2,
    
    [Description("V-Kanal")]
    VShape = 3
}

