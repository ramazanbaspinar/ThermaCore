using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    // ToolboxItem niteliği (attribute) yapıcı metodun üzerinden alınıp olması gerektiği gibi sınıfın üzerine taşındı.
    [ToolboxItem(true)]
    public class MyHyperlinkLabelControlPro : HyperlinkLabelControl, IStatusBarAciklama
    {
        public MyHyperlinkLabelControlPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Kullanıcı linkin üzerine geldiğinde farenin "El" simgesine dönüşmesini sağlar (Tıklanabilirlik hissi).
            Cursor = Cursors.Hand;

            // Linkin altının eski tip web sitelerindeki gibi sürekli çizgili kalmasını engeller. Daha modern ve temiz bir UI sunar.
            LinkBehavior = LinkBehavior.NeverUnderline;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit "Segoe UI" font tanımlaması silindi. Bileşen artık DevExpress temasının standart fontunu kullanacak.
        }

        // IStatusBarAciklama Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty ataması yapıldı.
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}