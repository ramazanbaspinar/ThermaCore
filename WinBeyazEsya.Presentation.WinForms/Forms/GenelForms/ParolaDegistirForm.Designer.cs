namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    partial class ParolaDegistirForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblBaslik = new DevExpress.XtraEditors.LabelControl();
            lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtEskiParola = new DevExpress.XtraEditors.TextEdit();
            txtYeniParola = new DevExpress.XtraEditors.TextEdit();
            txtYeniParolaTekrar = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            grpEskiParola = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            grpYeniParola = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            btnIptal = new DevExpress.XtraEditors.SimpleButton();
            btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEskiParola.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtYeniParola.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtYeniParolaTekrar.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpEskiParola).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpYeniParola).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(238, 29, 35);
            pnlHeader.Controls.Add(lblBaslik);
            pnlHeader.Controls.Add(lblAltBaslik);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(363, 55);
            pnlHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBaslik.Appearance.ForeColor = Color.White;
            lblBaslik.Appearance.Options.UseFont = true;
            lblBaslik.Appearance.Options.UseForeColor = true;
            lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblBaslik.Location = new Point(17, 10);
            lblBaslik.Margin = new Padding(3, 2, 3, 2);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(326, 23);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "🔐  Parola Değiştir";
            // 
            // lblAltBaslik
            // 
            lblAltBaslik.Appearance.Font = new Font("Segoe UI", 8.25F);
            lblAltBaslik.Appearance.ForeColor = Color.FromArgb(255, 200, 200);
            lblAltBaslik.Appearance.Options.UseFont = true;
            lblAltBaslik.Appearance.Options.UseForeColor = true;
            lblAltBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblAltBaslik.Location = new Point(17, 34);
            lblAltBaslik.Margin = new Padding(3, 2, 3, 2);
            lblAltBaslik.Name = "lblAltBaslik";
            lblAltBaslik.Size = new Size(326, 15);
            lblAltBaslik.TabIndex = 1;
            lblAltBaslik.Text = "Güvenliğiniz için parolanızı düzenli aralıklarla değiştiriniz.";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtEskiParola);
            layoutControl1.Controls.Add(txtYeniParola);
            layoutControl1.Controls.Add(txtYeniParolaTekrar);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 55);
            layoutControl1.Margin = new Padding(3, 2, 3, 2);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(363, 245);
            layoutControl1.TabIndex = 1;
            // 
            // txtEskiParola
            // 
            txtEskiParola.EnterMoveNextControl = true;
            txtEskiParola.Location = new Point(18, 52);
            txtEskiParola.Margin = new Padding(3, 2, 3, 2);
            txtEskiParola.Name = "txtEskiParola";
            txtEskiParola.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtEskiParola.Properties.Appearance.Options.UseFont = true;
            txtEskiParola.Properties.AppearanceFocused.BorderColor = Color.FromArgb(238, 29, 35);
            txtEskiParola.Properties.AppearanceFocused.Options.UseBorderColor = true;
            txtEskiParola.Properties.UseSystemPasswordChar = true;
            txtEskiParola.Size = new Size(327, 26);
            txtEskiParola.StyleController = layoutControl1;
            txtEskiParola.TabIndex = 0;
            // 
            // txtYeniParola
            // 
            txtYeniParola.EnterMoveNextControl = true;
            txtYeniParola.Location = new Point(18, 136);
            txtYeniParola.Margin = new Padding(3, 2, 3, 2);
            txtYeniParola.Name = "txtYeniParola";
            txtYeniParola.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtYeniParola.Properties.Appearance.Options.UseFont = true;
            txtYeniParola.Properties.AppearanceFocused.BorderColor = Color.FromArgb(238, 29, 35);
            txtYeniParola.Properties.AppearanceFocused.Options.UseBorderColor = true;
            txtYeniParola.Properties.UseSystemPasswordChar = true;
            txtYeniParola.Size = new Size(327, 26);
            txtYeniParola.StyleController = layoutControl1;
            txtYeniParola.TabIndex = 1;
            // 
            // txtYeniParolaTekrar
            // 
            txtYeniParolaTekrar.EnterMoveNextControl = true;
            txtYeniParolaTekrar.Location = new Point(18, 188);
            txtYeniParolaTekrar.Margin = new Padding(3, 2, 3, 2);
            txtYeniParolaTekrar.Name = "txtYeniParolaTekrar";
            txtYeniParolaTekrar.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtYeniParolaTekrar.Properties.Appearance.Options.UseFont = true;
            txtYeniParolaTekrar.Properties.AppearanceFocused.BorderColor = Color.FromArgb(238, 29, 35);
            txtYeniParolaTekrar.Properties.AppearanceFocused.Options.UseBorderColor = true;
            txtYeniParolaTekrar.Properties.UseSystemPasswordChar = true;
            txtYeniParolaTekrar.Size = new Size(327, 26);
            txtYeniParolaTekrar.StyleController = layoutControl1;
            txtYeniParolaTekrar.TabIndex = 2;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { grpEskiParola, grpYeniParola, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 5, 5);
            Root.Size = new Size(363, 245);
            Root.TextVisible = false;
            // 
            // grpEskiParola
            // 
            grpEskiParola.AppearanceGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpEskiParola.AppearanceGroup.ForeColor = Color.FromArgb(60, 60, 60);
            grpEskiParola.AppearanceGroup.Options.UseFont = true;
            grpEskiParola.AppearanceGroup.Options.UseForeColor = true;
            grpEskiParola.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            grpEskiParola.Location = new Point(0, 0);
            grpEskiParola.Name = "grpEskiParola";
            grpEskiParola.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            grpEskiParola.Size = new Size(345, 84);
            grpEskiParola.Text = "Mevcut Parola";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 8.75F);
            layoutControlItem1.AppearanceItemCaption.ForeColor = Color.FromArgb(100, 100, 100);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            layoutControlItem1.Control = txtEskiParola;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 5);
            layoutControlItem1.Size = new Size(333, 52);
            layoutControlItem1.Text = "Eski Parolanız";
            layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem1.TextSize = new Size(95, 15);
            // 
            // grpYeniParola
            // 
            grpYeniParola.AppearanceGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpYeniParola.AppearanceGroup.ForeColor = Color.FromArgb(60, 60, 60);
            grpYeniParola.AppearanceGroup.Options.UseFont = true;
            grpYeniParola.AppearanceGroup.Options.UseForeColor = true;
            grpYeniParola.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, layoutControlItem3 });
            grpYeniParola.Location = new Point(0, 84);
            grpYeniParola.Name = "grpYeniParola";
            grpYeniParola.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            grpYeniParola.Size = new Size(345, 136);
            grpYeniParola.Text = "Yeni Parola";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 8.75F);
            layoutControlItem2.AppearanceItemCaption.ForeColor = Color.FromArgb(100, 100, 100);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            layoutControlItem2.Control = txtYeniParola;
            layoutControlItem2.Location = new Point(0, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 5);
            layoutControlItem2.Size = new Size(333, 52);
            layoutControlItem2.Text = "Yeni Parolanız";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new Size(95, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 8.75F);
            layoutControlItem3.AppearanceItemCaption.ForeColor = Color.FromArgb(100, 100, 100);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            layoutControlItem3.Control = txtYeniParolaTekrar;
            layoutControlItem3.Location = new Point(0, 52);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 5);
            layoutControlItem3.Size = new Size(333, 52);
            layoutControlItem3.Text = "Yeni Parola Tekrar";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem3.TextSize = new Size(95, 15);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 220);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(345, 15);
            // 
            // panelControl1
            // 
            panelControl1.Appearance.BackColor = Color.FromArgb(245, 245, 245);
            panelControl1.Appearance.Options.UseBackColor = true;
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl1.Controls.Add(btnIptal);
            panelControl1.Controls.Add(btnKaydet);
            panelControl1.Dock = DockStyle.Bottom;
            panelControl1.Location = new Point(0, 300);
            panelControl1.Margin = new Padding(3, 2, 3, 2);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new Size(363, 45);
            panelControl1.TabIndex = 2;
            // 
            // btnIptal
            // 
            btnIptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIptal.Appearance.Font = new Font("Segoe UI", 9F);
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.DialogResult = DialogResult.Cancel;
            btnIptal.Location = new Point(270, 10);
            btnIptal.Margin = new Padding(3, 2, 3, 2);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(81, 26);
            btnIptal.TabIndex = 1;
            btnIptal.Text = "Vazgeç";
            btnIptal.Click += btnIptal_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKaydet.Appearance.BackColor = Color.FromArgb(238, 29, 35);
            btnKaydet.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnKaydet.Appearance.ForeColor = Color.White;
            btnKaydet.Appearance.Options.UseBackColor = true;
            btnKaydet.Appearance.Options.UseFont = true;
            btnKaydet.Appearance.Options.UseForeColor = true;
            btnKaydet.Location = new Point(143, 10);
            btnKaydet.Margin = new Padding(3, 2, 3, 2);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(122, 26);
            btnKaydet.TabIndex = 0;
            btnKaydet.Text = "Parolayı Güncelle";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // ParolaDegistirForm
            // 
            AcceptButton = btnKaydet;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnIptal;
            ClientSize = new Size(363, 345);
            Controls.Add(layoutControl1);
            Controls.Add(pnlHeader);
            Controls.Add(panelControl1);
            Font = new Font("Segoe UI", 8.25F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IconOptions.ShowIcon = false;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ParolaDegistirForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parola Değiştir";
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtEskiParola.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtYeniParola.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtYeniParolaTekrar.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpEskiParola).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpYeniParola).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup grpEskiParola;
        private DevExpress.XtraLayout.LayoutControlGroup grpYeniParola;
        private DevExpress.XtraEditors.TextEdit txtEskiParola;
        private DevExpress.XtraEditors.TextEdit txtYeniParola;
        private DevExpress.XtraEditors.TextEdit txtYeniParolaTekrar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}
