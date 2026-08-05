using System.Collections.Generic;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Registries
{
    public class SpecialPermissionDef
    {
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public static class SpecialPermissionRegistry
    {
        private static readonly Dictionary<ModuleType, List<SpecialPermissionDef>> _registry = new()
        {
            {
                ModuleType.Factory,
                new List<SpecialPermissionDef>
                {
                    new SpecialPermissionDef { Key = "CanProduceFason", Description = "Fason Üretim Yapabilir" },
                    new SpecialPermissionDef { Key = "CanChangeWastage", Description = "Fire Oranlarını Değiştirebilir" }
                }
            },
            {
                ModuleType.User,
                new List<SpecialPermissionDef>
                {
                    new SpecialPermissionDef { Key = "CanAddBackdated", Description = "Geçmişe Dönük Kayıt Girebilir" },
                    new SpecialPermissionDef { Key = "CanResetPassword", Description = "Diğer Kullanıcıların Şifresini Sıfırlayabilir" }
                }
            }
        };

        public static List<SpecialPermissionDef> GetPermissions(ModuleType module)
        {
            if (_registry.TryGetValue(module, out var permissions))
            {
                return permissions;
            }
            return new List<SpecialPermissionDef>();
        }
    }
}

