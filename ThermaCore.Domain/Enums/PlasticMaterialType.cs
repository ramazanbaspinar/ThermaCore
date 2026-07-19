using System.ComponentModel;

namespace ThermaCore.Domain.Enums
{
    public enum PlasticMaterialType
    {
        [Description("ABS")]
        ABS = 1,
        [Description("Polipropilen")]
        PP = 2,
        [Description("Poliamid-Cam Elyaflı")]
        PA66 = 3,
        [Description("Polikarbonat")]
        PC = 4,
        [Description("PBT-Isıya Dayanıklı")]
        PBT = 5
    }
}
