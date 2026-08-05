using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using WinBeyazEsya.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyPictureEdit : PictureEdit, IStatusBarKisaYol
    {
        public MyPictureEdit()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Bileşen boşken (resim yokken) ekranda gösterilecek standart metin.
            Properties.NullText = "Resim Yok";

            // Yüklenen resmin en-boy oranı fark etmeksizin bileşenin sınırlarına sığdırılmasını (esnetilmesini) sağlar.
            Properties.SizeMode = PictureSizeMode.Stretch;

            // DevExpress'in varsayılan sağ tık resim menüsünü gizler. Kullanıcıların yanlışlıkla resmi silmesini 
            // veya form yapısını bozacak işlemler yapmasını engeller.
            Properties.ShowMenu = false;
            Properties.ShowCameraMenuItem = CameraMenuItemVisibility.Auto;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" fontları ve odaklanıldığında yanan sarı arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık bu bileşenin görsel durumlarını otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty atamaları yapıldı.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = string.Empty;
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}
