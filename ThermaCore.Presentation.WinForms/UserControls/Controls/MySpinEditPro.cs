using DevExpress.Utils;
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MySpinEditPro : SpinEdit, IStatusBarAciklama
    {
        public MySpinEditPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Kullanıcının alanı boş (null) bırakmasını engeller. Sayısal giriş zorunluluğu sağlar (Örn: 0).
            Properties.AllowNullInput = DefaultBoolean.False;

            // Tam sayı (integer) maskesi ("n0"). Virgülden sonra küsurat girilmesini engeller.
            // ERP sistemlerinde adet, miktar veya sıra no gibi tam sayı gerektiren veri girişleri için kritiktir.
            Properties.EditMask = "n0";

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" fontları ve odaklanıldığında yanan sarı arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık artırma/azaltma (Spin) bileşenini otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty ataması yapıldı.
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}