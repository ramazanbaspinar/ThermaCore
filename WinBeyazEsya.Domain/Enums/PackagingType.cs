using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum PackagingType
{
    [Description("Koli")]
    Box = 1,
    
    [Description("Strafor-Köpük")]
    Styrofoam = 2,
    
    [Description("Şring Naylonu")]
    ShrinkFilm = 3,
    
    [Description("Palet")]
    Pallet = 4,
    
    [Description("Bant")]
    Tape = 5
}

