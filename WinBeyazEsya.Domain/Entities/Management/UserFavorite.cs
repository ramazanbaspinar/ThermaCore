using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Management
{
    public class UserFavorite : FullAuditableEntity
    {
        public long UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string FormCaption { get; set; }

        [Required]
        [StringLength(250)]
        public string FormTypeFullName { get; set; }
    }
}
