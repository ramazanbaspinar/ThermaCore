using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Production
{
    public class BurnerListDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string BaseUnit { get; set; } = string.Empty;
        public string BurnerTypeName { get; set; } = string.Empty;
        public decimal? SizeMm { get; set; }
        public decimal? PowerKw { get; set; }
        public string CapType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SpecialCodeName { get; set; } = string.Empty;
    }
}

