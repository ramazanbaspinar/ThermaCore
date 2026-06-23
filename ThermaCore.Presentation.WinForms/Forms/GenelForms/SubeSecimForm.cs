using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    public class SubeSecimForm : XtraForm
    {
        private LookUpEdit gluSube;
        private SimpleButton btnTamam;
        private SimpleButton btnIptal;
        private LabelControl lblBilgi;

        public long SeciliSubeId { get; private set; }
        public string SeciliSubeAdi { get; private set; }

        public SubeSecimForm(Dictionary<long, string> subeler)
        {
            InitializeComponent();

            gluSube.Properties.DataSource = subeler.Select(x => new { Id = x.Key, Ad = x.Value }).ToList();
            gluSube.Properties.DisplayMember = "Ad";
            gluSube.Properties.ValueMember = "Id";

            // Populate columns if needed
            gluSube.Properties.Columns.Clear();
            gluSube.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Şube/Fabrika Adı"));
        }

        private void InitializeComponent()
        {
            this.gluSube = new DevExpress.XtraEditors.LookUpEdit();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.gluSube.Properties)).BeginInit();
            this.SuspendLayout();
            
            // gluSube
            this.gluSube.Location = new System.Drawing.Point(20, 45);
            this.gluSube.Name = "gluSube";
            this.gluSube.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluSube.Properties.NullText = "Lütfen giriş yapmak istediğiniz Fabrika / Şubeyi seçiniz...";
            this.gluSube.Size = new System.Drawing.Size(350, 22);
            this.gluSube.TabIndex = 0;
            
            // lblBilgi
            this.lblBilgi.Location = new System.Drawing.Point(20, 20);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(300, 16);
            this.lblBilgi.Text = "Birden fazla fabrika yetkiniz bulunmaktadır.";
            
            // btnTamam
            this.btnTamam.Location = new System.Drawing.Point(214, 85);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 25);
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            
            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(295, 85);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 25);
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            
            // SubeSecimForm
            this.ClientSize = new System.Drawing.Size(390, 130);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.gluSube);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Şube / Fabrika Seçimi";
            
            ((System.ComponentModel.ISupportInitialize)(this.gluSube.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (gluSube.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen bir şube seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SeciliSubeId = Convert.ToInt64(gluSube.EditValue);
            SeciliSubeAdi = gluSube.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
