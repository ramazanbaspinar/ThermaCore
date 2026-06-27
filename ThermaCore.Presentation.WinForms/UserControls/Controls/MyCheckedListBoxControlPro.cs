using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckedListBoxControlPro : CheckedListBoxControl, IStatusBarKisaYol
    {
        public MyCheckedListBoxControlPro()
        {
            // --- İŞLEVSEL AYARLAR ---
            CheckOnClick = true; // Kullanıcının kutucuğu tutturmaya çalışmadan direkt satıra tıklayarak seçebilmesini sağlar.
            IncrementalSearch = true; // Klavyeden yazarak hızlı arama.
            SelectionMode = SelectionMode.One; // Çoklu tıklama karışıklığını engeller.

            // --- SAĞ TIK MENÜSÜ (Context Menu) ---
            var contextMenu = new ContextMenuStrip();

            var btnTumunuSec = new ToolStripMenuItem("Tümünü Seç");
            btnTumunuSec.Click += (s, e) => this.CheckAll();

            var btnTumunuKaldir = new ToolStripMenuItem("Tümünü Kaldır");
            btnTumunuKaldir.Click += (s, e) => this.UnCheckAll();

            contextMenu.Items.Add(btnTumunuSec);
            contextMenu.Items.Add(btnTumunuKaldir);

            this.ContextMenuStrip = contextMenu;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit Font ve Enter/Leave eventlerindeki sarı arka plan renk değişimleri kaldırıldı.
            // Tema motoru (Skin) bu listeyi ERP standartlarına göre otomatik yönetecek.
        }

        // CheckedListBoxControl doğrudan BaseEdit'ten türemediği için EnterMoveNextControl manuel olarak işlenir.
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && EnterMoveNextControl)
            {
                SendKeys.SendWait("{TAB}");
                e.Handled = true;
                return;
            }
            base.OnKeyDown(e);
        }

        public bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        // CS8618 uyarısını engellemek ve pragma'dan kurtulmak için string.Empty atamaları yapıldı.
        public string StatusBarKisaYol { get; set; } = "Space :";
        public string StatusBarKisaYolAciklama { get; set; } = string.Empty;
        public string StatusBarAciklama { get; set; } = string.Empty;
    }
}