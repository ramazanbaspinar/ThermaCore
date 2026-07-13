using System.ComponentModel;

namespace ThermaCore.Domain.Enums
{
    public enum BurnerType
    {
        [Description("Standart Bek")]
        Standard = 1,

        [Description("Havuz (Pool) Bek")]
        Pool = 2,

        [Description("Wok Bek")]
        Wok = 3,

        [Description("Kızartma (FryTop) Beki")]
        FryTop = 4,

        [Description("Fırın (Oven) Beki")]
        Oven = 5,
        
        [Description("Diğer")]
        Other = 99
    }
}
