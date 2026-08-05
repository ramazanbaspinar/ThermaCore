using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum PaperType
{
    [Description("1.Hamur")]
    Standard = 1,
    [Description("Kuşe")]
    Glossy = 2,
    [Description("Karton")]
    Cardboard = 3,
    [Description("Yapışkanlı")]
    Sticker = 4
}

