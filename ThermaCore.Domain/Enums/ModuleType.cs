using System.ComponentModel;

namespace ThermaCore.Domain.Enums;

public enum ModuleType
{
    [Description("Kullanıcı Rol Yönetimi")]
    UserRole = 1,
    [Description("Kullanıcı Yönetimi")]
    User = 2,
    [Description("Sistem Yönetimi")]
    Management = 3,
    [Description("Kod Şablonları")]
    KodSablonYonetimi = 4,
    [Description("Kod Üretim Logları")]
    KodLog = 5,
    [Description("Fabrikalar")]
    Factory = 6
}
