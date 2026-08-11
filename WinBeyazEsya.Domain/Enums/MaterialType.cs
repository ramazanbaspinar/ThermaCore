using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum MaterialType
{
    [Description("Metal ve Sac Grubu")]
    MetalAndSheet = 1,

    [Description("Elektrik ve Elektronik Grubu")]
    ElectricalElectronic = 2,

    [Description("Gaz ve Ateşleme Grubu")]
    GasAndIgnition = 3,

    [Description("Plastik ve Görsel Aksam Grubu")]
    PlasticAndVisualParts = 4,

    [Description("Kimya ve Yalıtım Grubu")]
    ChemicalAndInsulation = 5,

    [Description("Mekanik ve Hırdavat Grubu")]
    MechanicalAndHardware = 6,

    [Description("Ambalaj ve Matbaa Grubu")]
    PackagingAndPrinting = 7,

    [Description("Tel ve Izgara Grubu")]
    WireAndGrid = 8,

    [Description("Diğer Malzeme Grubu")]
    OtherMaterial = 9
}
