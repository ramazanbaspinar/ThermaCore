using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public class ReleaseNotesForm : XtraForm
    {
        public ReleaseNotesForm(string version, List<string> notes)
        {
            this.Text = $"Neler Yeni? - Sürüm {version}";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            LayoutControl layoutControl = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layoutControl);

            ListBoxControl listBox = new ListBoxControl();
            listBox.Appearance.Font = new Font("Segoe UI", 10);
            foreach (var note in notes)
            {
                listBox.Items.Add($"• {note}");
            }

            SimpleButton btnClose = new SimpleButton { Text = "Kapat", Height = 40 };
            btnClose.Click += (s, e) => this.Close();

            var itemListBox = layoutControl.Root.AddItem("Yenilikler:", listBox);
            itemListBox.TextLocation = DevExpress.Utils.Locations.Top;
            itemListBox.AppearanceItemCaption.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            var itemBtn = layoutControl.Root.AddItem("", btnClose);
            itemBtn.TextVisible = false;
        }
    }
}

