using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum HandleType
{
    [Description("Fırın Kapağı")]
    OvenDoor = 1,

    [Description("Çekmece")]
    Drawer = 2
}
