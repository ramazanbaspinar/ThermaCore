namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlceTanimForms
{
    partial class IlceTanimEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            txtName = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            tgsIsActive = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            txtCode = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tgsIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(398, 155);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Location = new Point(0, 0);
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            columnDefinition2.SizeType = SizeType.Absolute;
            columnDefinition2.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3 });
            Root.Size = new Size(609, 216);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(490, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(45, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Location = new Point(490, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem2.Size = new Size(99, 31);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Location = new Point(0, 31);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem3.Size = new Size(589, 31);
            layoutControlItem3.Text = "İl Adı";
            layoutControlItem3.TextSize = new Size(45, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Location = new Point(0, 62);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem4.Size = new Size(589, 134);
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(45, 13);
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(txtName);
            myDataLayoutControl1.Controls.Add(tgsIsActive);
            myDataLayoutControl1.Controls.Add(txtCode);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 155);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = layoutControlGroup1;
            myDataLayoutControl1.Size = new Size(398, 113);
            myDataLayoutControl1.TabIndex = 3;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtName
            // 
            txtName.EnterMoveNextControl = true;
            txtName.Location = new Point(61, 43);
            txtName.MenuManager = ribbon;
            txtName.Name = "txtName";
            txtName.Properties.MaxLength = 100;
            txtName.Size = new Size(325, 22);
            txtName.StatusBarAciklama = "";
            txtName.StyleController = myDataLayoutControl1;
            txtName.TabIndex = 0;
            txtName.Tag = "Title";
            // 
            // tgsIsActive
            // 
            tgsIsActive.EnterMoveNextControl = true;
            tgsIsActive.Location = new Point(291, 12);
            tgsIsActive.MenuManager = ribbon;
            tgsIsActive.Name = "tgsIsActive";
            tgsIsActive.Properties.AutoHeight = false;
            tgsIsActive.Properties.AutoWidth = true;
            tgsIsActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            tgsIsActive.Properties.OffText = "Pasif";
            tgsIsActive.Properties.OnText = "Aktif";
            tgsIsActive.Size = new Size(81, 27);
            tgsIsActive.StatusBarAciklama = "Kayıtın Kullanım Durumunu Seçiniz.";
            tgsIsActive.StyleController = myDataLayoutControl1;
            tgsIsActive.TabIndex = 2;
            tgsIsActive.Tag = "IsActive";
            // 
            // txtCode
            // 
            txtCode.EnterMoveNextControl = true;
            txtCode.Location = new Point(61, 12);
            txtCode.MenuManager = ribbon;
            txtCode.Name = "txtCode";
            txtCode.Properties.Appearance.Options.UseTextOptions = true;
            txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtCode.Properties.MaxLength = 100;
            txtCode.Size = new Size(226, 22);
            txtCode.StatusBarAciklama = "Kod Giriniz.";
            txtCode.StyleController = myDataLayoutControl1;
            txtCode.TabIndex = 3;
            txtCode.Tag = "Code";
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem5, layoutControlItem6, layoutControlItem7 });
            layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            layoutControlGroup1.Name = "Root";
            columnDefinition3.SizeType = SizeType.Percent;
            columnDefinition3.Width = 100D;
            columnDefinition4.SizeType = SizeType.Absolute;
            columnDefinition4.Width = 99D;
            layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition3, columnDefinition4 });
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            rowDefinition5.Height = 31D;
            rowDefinition5.SizeType = SizeType.Absolute;
            layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition4, rowDefinition5 });
            layoutControlGroup1.Size = new Size(398, 113);
            layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtCode;
            layoutControlItem5.Location = new Point(0, 0);
            layoutControlItem5.Name = "layoutControlItem1";
            layoutControlItem5.Size = new Size(279, 31);
            layoutControlItem5.Text = "Kod";
            layoutControlItem5.TextSize = new Size(37, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = tgsIsActive;
            layoutControlItem6.Location = new Point(279, 0);
            layoutControlItem6.Name = "layoutControlItem2";
            layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem6.Size = new Size(99, 31);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = txtName;
            layoutControlItem7.Location = new Point(0, 31);
            layoutControlItem7.Name = "layoutControlItem3";
            layoutControlItem7.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem7.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem7.Size = new Size(378, 62);
            layoutControlItem7.Text = "İlçe Adı";
            layoutControlItem7.TextSize = new Size(37, 13);
            // 
            // IlceTanimEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "IlceTanimEditForm";
            Text = "İlçe Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tgsIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyTextEdit txtName;
        private UserControls.Controls.MyToggleSwitch tgsIsActive;
        private UserControls.Controls.MyKodTextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}