using DevExpress.XtraEditors;
using WinBeyazEsya.Presentation.WinForms.Interfaces;
using System.ComponentModel;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyMemoEdit : MemoEdit, IStatusBarAciklama
    {
        public MyMemoEdit()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Veritabanı taşma (overflow) hatalarını engellemek için standart karakter sınırı.
            // Açıklama, Adres veya Not gibi uzun metin alanları için veri bütünlüğünü korur.
            Properties.MaxLength = 500;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" fontları ve odaklanıldığında yanan sarı arka plan rengi silindi.
            // DevExpress Skin (Tema) motoru artık çoklu satır metin kutusunu otomatik yönetecek.
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        // UFAK BİR NOT: MemoEdit çoklu satır bir kutu olduğu için, Enter ile sonraki kontrole geçmek
        // kullanıcının Enter ile alt satıra inmesini engeller (Alt satıra inmek için Ctrl+Enter basması gerekir). 
        // Hızlı veri girişi yapılan ERP'lerde bu genelde istenen bir durumdur, bu yüzden koruyoruz.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarAciklama Implementasyonu
        // Başlangıç değeri atandığı için CS8618 uyarısı zaten oluşmaz.
        public string StatusBarAciklama { get; set; } = "Açıklama Giriniz.";
    }
}
