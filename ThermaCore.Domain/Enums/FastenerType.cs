using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum FastenerType
{
    [Description("Somun")]
    Nut = 1,
    
    [Description("Pul")]
    Washer = 2,
    
    [Description("Perçin")]
    Rivet = 3,
    
    [Description("Yay")]
    Spring = 4,
    
    [Description("Kelepçe")]
    Clamp = 5,
    
    [Description("Klips")]
    Clip = 6
}
