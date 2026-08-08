using System.ComponentModel;
using WinBeyazEsya.Domain.Attributes;

namespace WinBeyazEsya.Domain.Enums;

public enum ModuleType
{
    // ANA MENÜLER (Root)
    [Description("Ayarlar")]
    Ayarlar = 1000,

    [Description("Tanımlar")]
    Tanimlar = 2000,

    [Description("Maliyetler")]
    Maliyetler = 3000,


    // ALT MENÜLER (Klasörler) - AYARLAR
    [Description("Kurumsal Tanımlar")]
    [ParentModule(Ayarlar)]
    KurumsalTanimlar = 1001,

    [Description("Güvenlik ve Yetkilendirme")]
    [ParentModule(Ayarlar)]
    GuvenlikVeYetkilendirme = 1002,

    [Description("Parametreler")]
    [ParentModule(Ayarlar)]
    Parametreler = 1003,


    // ALT MENÜLER (Klasörler) - TANIMLAR
    [Description("Temel Tanımlar")]
    [ParentModule(Tanimlar)]
    TemelTanimlar = 2001,


    // MODÜLLER (Ekranlar) - KURUMSAL TANIMLAR (Ayarlar -> Kurumsal Tanımlar)
    [Description("Şirket Tanımları")]
    [ParentModule(KurumsalTanimlar)]
    SirketTanimlari = 1,

    [Description("Fabrikalar")]
    [ParentModule(KurumsalTanimlar)]
    [RequiresCodeTemplate]
    Factory = 2,


    // MODÜLLER (Ekranlar) - GÜVENLİK VE YETKİLENDİRME (Ayarlar -> Güvenlik ve Yetkilendirme)
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


    // MODÜLLER (Ekranlar) - PARAMETRELER (Ayarlar -> Parametreler)
    [Description("Kullanıcı Arayüz Şablonları")]
    [ParentModule(Parametreler)]
    UserInterfaceTemplate = 10,

    [Description("Kod Şablonları")]
    [ParentModule(Parametreler)]
    CodeTemplateYonetimi = 6,

    [Description("E-Mail Parametreleri")]
    [ParentModule(Parametreler)]
    EmailParameter = 8,

    [Description("Sistem Lisansı")]
    [ParentModule(Parametreler)]
    SystemLicense = 9,

    [Description("Genel Parametreler")]
    [ParentModule(Parametreler)]
    GenelParametreler = 1004,

    [Description("Kod Üretim Logları")]
    [ParentModule(Parametreler)]
    KodLog = 7,

    [Description("Kod Yönetimi")]
    [ParentModule(Parametreler)]
    KodYonetimi = 18,


    // MODÜLLER (Ekranlar) - TEMEL TANIMLAR (Tanımlar -> Temel Tanımlar)
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
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    MetalVeSacGrubu = 17,

    [Description("Elektrik ve Elektronik Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    ElektrikVeElektronikGrubu = 19,

    [Description("Gaz ve Ateşleme Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    GazveAteslemeGrubu = 20,

    [Description("Plastik ve Görsel Aksam Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    PlastikVeGorselAksamGrubu = 21,

    [Description("Kimya ve Yalıtım Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    KimyaVeYalitimGrubu = 22,

    [Description("Mekanik ve Hırdavat Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    MekanikVeHirdavatGrubu = 23,

    [Description("Ambalaj ve Matbaa Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    AmbalajVeMatbaaGrubu = 24,

    [Description("Tel ve Izgara Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    TelVeIzgaraGrubu = 25,

    [Description("Diğer Malzeme Grubu")]
    [ParentModule(TemelTanimlar)]
    [RequiresCodeTemplate]
    DigerMalzemeGrubu = 26,

    // MODÜLLER (Ekranlar) - MALİYETLER
    [Description("Genel Giderler")]
    [ParentModule(Maliyetler)]
    [RequiresCodeTemplate]
    GenelGiderler = 15,

    [Description("Maliyet Parametreleri")]
    [ParentModule(Maliyetler)]
    [RequiresCodeTemplate]
    MaliyetParametreleri = 16,
}
