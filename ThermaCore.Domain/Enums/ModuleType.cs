using System.ComponentModel;
using ThermaCore.Domain.Attributes;

namespace ThermaCore.Domain.Enums;

public enum ModuleType
{
    // ANA MENÜLER (Root)
    [Description("Sistem Yönetimi")]
    SistemYonetimi = 1000,

    // ALT MENÜLER (Klasörler)
    [Description("Kurumsal Tanımlar")]
    [ParentModule(SistemYonetimi)]
    KurumsalTanimlar = 1001,

    [Description("Güvenlik ve Yetkilendirme")]
    [ParentModule(SistemYonetimi)]
    GuvenlikVeYetkilendirme = 1002,

    [Description("Parametreler")]
    [ParentModule(SistemYonetimi)]
    Parametreler = 1003,

    // MODÜLLER (Ekranlar)
    [Description("Şirket Tanımları")]
    [ParentModule(KurumsalTanimlar)]
    SirketTanimlari = 1,

    [Description("Fabrikalar")]
    [ParentModule(KurumsalTanimlar)]
    [RequiresCodeTemplate]
    Factory = 2,

    [Description("Yetki Grupları (Roller)")]
    [ParentModule(GuvenlikVeYetkilendirme)]
    [RequiresCodeTemplate]
    YetkiGruplari = 3,

    [Description("Kullanıcı Tanımları")]
    [ParentModule(GuvenlikVeYetkilendirme)]
    User = 4,

    [Description("Terminal Cihaz Yönetimi")]
    [ParentModule(GuvenlikVeYetkilendirme)]
    [RequiresCodeTemplate]
    TerminalYonetimi = 5,

    [Description("Kod Şablonları")]
    [ParentModule(Parametreler)]
    CodeTemplateYonetimi = 6,

    [Description("Kod Üretim Logları")]
    [ParentModule(Parametreler)]
    KodLog = 7
}
