using DevExpress.Utils;
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyDateEditPro : DateEdit, IStatusBarKisaYol
    {
        public MyDateEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Tarih alanının boş (null) bırakılmasını engeller (Kayıt, fiş veya fatura tarihleri için kritiktir).
            Properties.AllowNullInput = DefaultBoolean.False;

            // Tarih metnini yatayda ortalar, form üzerinde çok daha hizalı ve okunaklı durmasını sağlar.
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

            // Kullanıcı tarihi klavyeden tuşlarken gün/ay/yıl arasında imlecin otomatik atlamasını sağlar (Hızlı giriş UX).
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" fontları ve odaklanıldığında yanan sarı arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık bu bileşenin görsel durumlarını otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole (Örn: Fiş Numarası alanına) geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty ataması yapıldı.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Tarih Seç";
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}