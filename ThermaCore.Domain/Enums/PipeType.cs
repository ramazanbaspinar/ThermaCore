using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum PipeType
{
    [Description("Alüminyum")]
    Aluminum = 1,

    [Description("Bakır")]
    Copper = 2,
    
    [Description("Çelik")]
    Steel = 3,

    [Description("Diğer")]
    Other = 4
}
