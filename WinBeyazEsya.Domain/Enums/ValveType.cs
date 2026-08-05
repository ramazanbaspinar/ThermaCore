using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum ValveType
{
    [Description("Termostatik")]
    Thermostatic = 1,

    [Description("Solenoid")]
    Solenoid = 2,

    [Description("Manuel Emniyetli")]
    ManualSafety = 3,

    [Description("Diğer")]
    Other = 99
}

