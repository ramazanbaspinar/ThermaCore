using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum SurfaceCoatingType
{
    [Description("Boya")] Boya = 1,
    [Description("Emaye")] Emaye = 2,
    [Description("Diğer")] Diger = 3,
    [Description("Kaplamasız")] Kaplamasiz = 4,
}
