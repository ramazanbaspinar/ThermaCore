namespace ThermaCore.Presentation.WinForms.Forms.ParametrelerForms
{
    partial class EmailParameterEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            chkEnableSsl = new ThermaCore.Presentation.WinForms.UserControls.MyCheckEdit();
            txtPassword = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtSenderEmail = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtSenderName = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtPort = new ThermaCore.Presentation.WinForms.UserControls.MySpinEdit();
            txtSmtpServer = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkEnableSsl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSenderEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSenderName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPort.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSmtpServer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(348, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(chkEnableSsl);
            myDataLayoutControl1.Controls.Add(txtPassword);
            myDataLayoutControl1.Controls.Add(txtSenderEmail);
            myDataLayoutControl1.Controls.Add(txtSenderName);
            myDataLayoutControl1.Controls.Add(txtPort);
            myDataLayoutControl1.Controls.Add(txtSmtpServer);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(348, 180);
            myDataLayoutControl1.TabIndex = 2;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // chkEnableSsl
            // 
            chkEnableSsl.EnterMoveNextControl = true;
            chkEnableSsl.Location = new Point(12, 167);
            chkEnableSsl.MenuManager = ribbon;
            chkEnableSsl.Name = "chkEnableSsl";
            chkEnableSsl.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            chkEnableSsl.Properties.Appearance.Options.UseFont = true;
            chkEnableSsl.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            chkEnableSsl.Properties.AppearanceDisabled.Options.UseFont = true;
            chkEnableSsl.Properties.AppearanceFocused.BackColor = Color.Transparent;
            chkEnableSsl.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            chkEnableSsl.Properties.AppearanceFocused.Options.UseBackColor = true;
            chkEnableSsl.Properties.AppearanceFocused.Options.UseFont = true;
            chkEnableSsl.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            chkEnableSsl.Properties.AppearanceReadOnly.Options.UseFont = true;
            chkEnableSsl.Properties.Caption = "SSL Etkin";
            chkEnableSsl.Size = new Size(307, 20);
            chkEnableSsl.StatusBarAciklama = null;
            chkEnableSsl.StyleController = myDataLayoutControl1;
            chkEnableSsl.TabIndex = 9;
            chkEnableSsl.Tag = "EnableSsl";
            // 
            // txtPassword
            // 
            txtPassword.EnterMoveNextControl = true;
            txtPassword.Location = new Point(113, 136);
            txtPassword.MenuManager = ribbon;
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtPassword.Properties.AppearanceDisabled.Options.UseFont = true;
            txtPassword.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtPassword.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtPassword.Properties.AppearanceFocused.Options.UseFont = true;
            txtPassword.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtPassword.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtPassword.Properties.MaxLength = 100;
            txtPassword.Size = new Size(206, 22);
            txtPassword.StatusBarAciklama = null;
            txtPassword.StyleController = myDataLayoutControl1;
            txtPassword.TabIndex = 8;
            txtPassword.Tag = "Password";
            // 
            // txtSenderEmail
            // 
            txtSenderEmail.EnterMoveNextControl = true;
            txtSenderEmail.Location = new Point(113, 105);
            txtSenderEmail.MenuManager = ribbon;
            txtSenderEmail.Name = "txtSenderEmail";
            txtSenderEmail.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtSenderEmail.Properties.Appearance.Options.UseFont = true;
            txtSenderEmail.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtSenderEmail.Properties.AppearanceDisabled.Options.UseFont = true;
            txtSenderEmail.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtSenderEmail.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtSenderEmail.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtSenderEmail.Properties.AppearanceFocused.Options.UseFont = true;
            txtSenderEmail.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtSenderEmail.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtSenderEmail.Properties.MaxLength = 100;
            txtSenderEmail.Size = new Size(206, 22);
            txtSenderEmail.StatusBarAciklama = null;
            txtSenderEmail.StyleController = myDataLayoutControl1;
            txtSenderEmail.TabIndex = 7;
            txtSenderEmail.Tag = "SenderEmail";
            // 
            // txtSenderName
            // 
            txtSenderName.EnterMoveNextControl = true;
            txtSenderName.Location = new Point(113, 74);
            txtSenderName.MenuManager = ribbon;
            txtSenderName.Name = "txtSenderName";
            txtSenderName.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtSenderName.Properties.Appearance.Options.UseFont = true;
            txtSenderName.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtSenderName.Properties.AppearanceDisabled.Options.UseFont = true;
            txtSenderName.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtSenderName.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtSenderName.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtSenderName.Properties.AppearanceFocused.Options.UseFont = true;
            txtSenderName.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtSenderName.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtSenderName.Properties.MaxLength = 100;
            txtSenderName.Size = new Size(206, 22);
            txtSenderName.StatusBarAciklama = null;
            txtSenderName.StyleController = myDataLayoutControl1;
            txtSenderName.TabIndex = 6;
            txtSenderName.Tag = "SenderName";
            // 
            // txtPort
            // 
            txtPort.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtPort.EnterMoveNextControl = true;
            txtPort.Location = new Point(113, 43);
            txtPort.MenuManager = ribbon;
            txtPort.Name = "txtPort";
            txtPort.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtPort.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtPort.Properties.Appearance.Options.UseFont = true;
            txtPort.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtPort.Properties.AppearanceDisabled.Options.UseFont = true;
            txtPort.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtPort.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtPort.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtPort.Properties.AppearanceFocused.Options.UseFont = true;
            txtPort.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtPort.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtPort.Properties.MaskSettings.Set("mask", "n0");
            txtPort.Properties.MaxValue = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtPort.Size = new Size(206, 22);
            txtPort.StatusBarAciklama = null;
            txtPort.StyleController = myDataLayoutControl1;
            txtPort.TabIndex = 5;
            txtPort.Tag = "Port";
            // 
            // txtSmtpServer
            // 
            txtSmtpServer.EditValue = "";
            txtSmtpServer.EnterMoveNextControl = true;
            txtSmtpServer.Location = new Point(113, 12);
            txtSmtpServer.MenuManager = ribbon;
            txtSmtpServer.Name = "txtSmtpServer";
            txtSmtpServer.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtSmtpServer.Properties.Appearance.Options.UseFont = true;
            txtSmtpServer.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtSmtpServer.Properties.AppearanceDisabled.Options.UseFont = true;
            txtSmtpServer.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtSmtpServer.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtSmtpServer.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtSmtpServer.Properties.AppearanceFocused.Options.UseFont = true;
            txtSmtpServer.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtSmtpServer.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtSmtpServer.Properties.MaxLength = 100;
            txtSmtpServer.Size = new Size(206, 22);
            txtSmtpServer.StatusBarAciklama = null;
            txtSmtpServer.StyleController = myDataLayoutControl1;
            txtSmtpServer.TabIndex = 4;
            txtSmtpServer.Tag = "SmtpServer";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            rowDefinition5.Height = 31D;
            rowDefinition5.SizeType = SizeType.Absolute;
            rowDefinition6.Height = 31D;
            rowDefinition6.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5, rowDefinition6 });
            Root.Size = new Size(331, 206);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtSmtpServer;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(311, 31);
            layoutControlItem1.Text = "Smtp Server";
            layoutControlItem1.TextSize = new Size(89, 15);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtPort;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(311, 31);
            layoutControlItem2.Text = "Port";
            layoutControlItem2.TextSize = new Size(89, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtSenderName;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(311, 31);
            layoutControlItem3.Text = "Gönderen Adı";
            layoutControlItem3.TextSize = new Size(89, 15);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = txtSenderEmail;
            layoutControlItem4.Location = new Point(0, 93);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(311, 31);
            layoutControlItem4.Text = "Gönderen E-Mail";
            layoutControlItem4.TextSize = new Size(89, 15);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = txtPassword;
            layoutControlItem5.Location = new Point(0, 124);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 4;
            layoutControlItem5.Size = new Size(311, 31);
            layoutControlItem5.Text = "Şifre";
            layoutControlItem5.TextSize = new Size(89, 15);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem6.Control = chkEnableSsl;
            layoutControlItem6.Location = new Point(0, 155);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.OptionsTableLayoutItem.RowIndex = 5;
            layoutControlItem6.Size = new Size(311, 31);
            layoutControlItem6.TextVisible = false;
            // 
            // EmailParameterEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 339);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(350, 340);
            Name = "EmailParameterEditForm";
            Text = "E-Mail Parametre Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkEnableSsl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSenderEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSenderName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPort.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSmtpServer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.MySpinEdit txtPort;
        private UserControls.MyTextEdit txtSmtpServer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private UserControls.MyCheckEdit chkEnableSsl;
        private UserControls.MyTextEdit txtPassword;
        private UserControls.MyTextEdit txtSenderEmail;
        private UserControls.MyTextEdit txtSenderName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}