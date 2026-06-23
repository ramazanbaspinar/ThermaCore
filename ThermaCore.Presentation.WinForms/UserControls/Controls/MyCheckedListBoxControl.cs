#pragma warning disable CS8618
using DevExpress.XtraEditors;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyCheckedListBoxControl : CheckedListBoxControl, IStatusBarKisaYol
    {
        public MyCheckedListBoxControl()
        {
            Appearance.Font = new Font("Segoe UI", 9f);

            CheckOnClick = true;
            IncrementalSearch = true;
            SelectionMode = SelectionMode.One;

            Enter += MyCheckedListBoxControl_Enter;
            Leave += MyCheckedListBoxControl_Leave;

            var contextMenu = new ContextMenuStrip();
            
            var btnTumunuSec = new ToolStripMenuItem("Tümünü Seç");
            btnTumunuSec.Click += (s, e) => this.CheckAll();
            
            var btnTumunuKaldir = new ToolStripMenuItem("Tümünü Kaldır");
            btnTumunuKaldir.Click += (s, e) => this.UnCheckAll();
            
            contextMenu.Items.Add(btnTumunuSec);
            contextMenu.Items.Add(btnTumunuKaldir);
            
            this.ContextMenuStrip = contextMenu;
        }

        private void MyCheckedListBoxControl_Enter(object? sender, EventArgs e)
        {
            Appearance.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void MyCheckedListBoxControl_Leave(object? sender, EventArgs e)
        {
            Appearance.BackColor = Color.Empty;
        }

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

        // CheckedListBoxControl sınıfı doğrudan BaseEdit'ten türemediği için (BaseControl'den türer)
        // override edilebilecek bir EnterMoveNextControl özelliği yoktur. Bu yüzden 'new' veya doğrudan özellik olarak tanımlanır.
        public bool EnterMoveNextControl { get; set; } = true;
        
        public string StatusBarKisaYol { get; set; } = "Space :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
