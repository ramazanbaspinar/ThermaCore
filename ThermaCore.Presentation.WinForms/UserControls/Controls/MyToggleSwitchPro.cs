using DevExpress.Utils;
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyToggleSwitchPro : ToggleSwitch, IStatusBarAciklama
    {
        public MyToggleSwitchPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // "Aktif/Pasif" metinleri ERP sistemleri için standart ve anlaşılırdır.
            Properties.OffText = "Pasif";
            Properties.OnText = "Aktif";

            // Kontrolün otomatik boyutlanması, arayüz düzenini (Layout) korumak için kritiktir.
            Properties.AutoHeight = false;
            Properties.AutoWidth = true;

            // Metin ve anahtarın hizalanması.
            Properties.GlyphAlignment = HorzAlignment.Far;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" font tanımlamaları silindi.
            // DevExpress Skin (Tema) motoru artık bu bileşenin yazı tiplerini otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama Implementasyonu
        public string StatusBarAciklama { get; set; } = "Kayıtın Kullanım Durumunu Seçiniz.";
    }
}