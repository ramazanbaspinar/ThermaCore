using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum MaterialType
{
    [Description("Alüminyum")]
    Aluminum = 1,

    [Description("Plastik")]
    Plastic = 2,

    [Description("Bakalit")]
    Bakelite = 3,

    [Description("İnoks")]
    Inox = 4,

    [Description("Pirinç-Sarı")]
    Brass = 5,

    [Description("Çelik")]
    Steel = 6,

    [Description("Zamak-Döküm")]
    Zinc = 7
}

