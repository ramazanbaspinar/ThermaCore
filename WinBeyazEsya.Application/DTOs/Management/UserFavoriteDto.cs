using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Management
{
    public class UserFavoriteDto : BaseDto
    {
        public long UserId { get; set; }
        public string FormCaption { get; set; }
        public string FormTypeFullName { get; set; }
    }
}
