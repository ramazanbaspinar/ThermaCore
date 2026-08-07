using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class SurumNotlariForm : XtraForm
    {
        public SurumNotlariForm(string version, List<string> notes)
        {
            InitializeComponent();

            // Başlık ve sürüm bilgisi
            this.Text = $"Neler Yeni? — Sürüm {version}";
            lblHeaderTitle.Text = "Neler Yeni?";
            lblVersionBadge.Text = $"v{version}";

            // Sürüm notlarını RichTextBox'a yükle
            if (notes != null && notes.Count > 0)
            {
                txtNotes.Clear();
                foreach (var note in notes)
                {
                    txtNotes.SelectionFont = new Font("Segoe UI", 11F);
                    txtNotes.SelectionColor = Color.FromArgb(220, 220, 230);
                    txtNotes.AppendText($"  •  {note}\n\n");
                }
                // İmleci en başa al
                txtNotes.SelectionStart = 0;
                txtNotes.ScrollToCaret();
            }
            else
            {
                txtNotes.Text = "Bu sürümde henüz not bulunmamaktadır.";
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
