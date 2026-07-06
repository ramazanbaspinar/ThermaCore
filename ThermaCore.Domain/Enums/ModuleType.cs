using System.ComponentModel;
using ThermaCore.Domain.Attributes;

namespace ThermaCore.Domain.Enums;

public enum ModuleType
{
    // ANA MENÜLER (Root)
    [Description("Sistem Yönetimi")]
    SistemYonetimi = 1000,

    [Description("Genel Parametreler")]
    [ParentModule(SistemYonetimi)]
    GenelParametreler = 1004,

    [Description("Tanımlar")]
    Tanimlar = 2000,

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
    TerminalYonetimi = 5,

    [Description("Kod Şablonları")]
    [ParentModule(Parametreler)]
    CodeTemplateYonetimi = 6,

    [Description("Kod Üretim Logları")]
    [ParentModule(Parametreler)]
    KodLog = 7,

    [Description("E-Mail Parametreleri")]
    [ParentModule(Parametreler)]
    EmailParameter = 8,

    [Description("Sistem Lisansı")]
    [ParentModule(Parametreler)]
    SystemLicense = 9,

    [Description("Kullanıcı Arayüz Şablonları")]
    [ParentModule(Parametreler)]
    UserInterfaceTemplate = 10,

    [Description("Temel Tanımlar")]
    [ParentModule(Tanimlar)]
    TemelTanimlar = 2001,

    [Description("Birim Tanımları")]
    [ParentModule(TemelTanimlar)]
    BirimTanimlari = 11,

    [Description("Kur Tanımları")]
    [ParentModule(TemelTanimlar)]
    KurTanimlari = 12,

    [Description("KDV Oranları")]
    [ParentModule(TemelTanimlar)]
    KdvOranlari = 13,

    [Description("ÖTV Oranları")]
    [ParentModule(TemelTanimlar)]
    OtvOranlari = 14,

    [Description("Metal ve Sac Grubu")]
    [ParentModule(Tanimlar)]
    MetalVeSacGrubu = 3000,


    [Description("Sac Tanımları")]
    [ParentModule(MetalVeSacGrubu)]
    [RequiresCodeTemplate]
    SacTanimlari = 16,

    [Description("Kalite Standart Tanımları")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    KaliteStandartTanimlari = 17,

    [Description("Yüzey Tipi Tanımları")]
    [ParentModule(MetalVeSacGrubu)]
    [RequiresCodeTemplate]
    YuzeyTipiTanimlari = 17,

    [Description("Kod Yönetimi")]
    [ParentModule(SistemYonetimi)]
    KodYonetimi = 18,

    [Description("Boya Tanımları")]
    [ParentModule(Tanimlar)]
    [RequiresCodeTemplate]
    BoyaTanimlari = 19
}
