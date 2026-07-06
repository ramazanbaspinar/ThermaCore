namespace ThermaCore.Presentation.WinForms.UserControls
{
    partial class ucEntityPicture
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureEdit1 = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmResimSec = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKameradanCek = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResmiBuyut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResmiIndir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResmiSil = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EnterMoveNextControl = true;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.pictureEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.pictureEdit1.Properties.NullText = "Resim Yok";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(200, 200);
            this.pictureEdit1.StatusBarAciklama = null;
            this.pictureEdit1.StatusBarKisaYol = "F4 : ";
            this.pictureEdit1.StatusBarKisaYolAciklama = null;
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmResimSec,
            this.tsmKameradanCek,
            this.tsmResmiBuyut,
            this.tsmResmiIndir,
            this.tsmResmiSil});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 114);
            // 
            // tsmResimSec
            // 
            this.tsmResimSec.Name = "tsmResimSec";
            this.tsmResimSec.Size = new System.Drawing.Size(156, 22);
            this.tsmResimSec.Text = "Resim Seç";
            this.tsmResimSec.Click += new System.EventHandler(this.tsmResimSec_Click);
            // 
            // tsmKameradanCek
            // 
            this.tsmKameradanCek.Name = "tsmKameradanCek";
            this.tsmKameradanCek.Size = new System.Drawing.Size(156, 22);
            this.tsmKameradanCek.Text = "Kameradan Çek";
            this.tsmKameradanCek.Click += new System.EventHandler(this.tsmKameradanCek_Click);
            // 
            // tsmResmiBuyut
            // 
            this.tsmResmiBuyut.Name = "tsmResmiBuyut";
            this.tsmResmiBuyut.Size = new System.Drawing.Size(156, 22);
            this.tsmResmiBuyut.Text = "Resmi Büyüt";
            this.tsmResmiBuyut.Click += new System.EventHandler(this.tsmResmiBuyut_Click);
            // 
            // tsmResmiIndir
            // 
            this.tsmResmiIndir.Name = "tsmResmiIndir";
            this.tsmResmiIndir.Size = new System.Drawing.Size(156, 22);
            this.tsmResmiIndir.Text = "Resmi İndir";
            this.tsmResmiIndir.Click += new System.EventHandler(this.tsmResmiIndir_Click);
            // 
            // tsmResmiSil
            // 
            this.tsmResmiSil.Name = "tsmResmiSil";
            this.tsmResmiSil.Size = new System.Drawing.Size(156, 22);
            this.tsmResmiSil.Text = "Resim Sil";
            this.tsmResmiSil.Click += new System.EventHandler(this.tsmResmiSil_Click);
            // 
            // ucEntityPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureEdit1);
            this.Name = "ucEntityPicture";
            this.Size = new System.Drawing.Size(200, 200);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit pictureEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmResimSec;
        private System.Windows.Forms.ToolStripMenuItem tsmKameradanCek;
        private System.Windows.Forms.ToolStripMenuItem tsmResmiBuyut;
        private System.Windows.Forms.ToolStripMenuItem tsmResmiIndir;
        private System.Windows.Forms.ToolStripMenuItem tsmResmiSil;
    }
}
