namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlTanimForms
{
    partial class IlTanimEditForm
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
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            txtName = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            tgsIsActive = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            txtCode = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tgsIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(398, 155);
            ribbon.Toolbar.ShowCustomizeItem = false;
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
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 113);
            myDataLayoutControl1.TabIndex = 2;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtName
            // 
            txtName.EnterMoveNextControl = true;
            txtName.Location = new Point(50, 43);
            txtName.MenuManager = ribbon;
            txtName.Name = "txtName";
            txtName.Properties.MaxLength = 100;
            txtName.Size = new Size(336, 22);
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
            txtCode.Location = new Point(50, 12);
            txtCode.MenuManager = ribbon;
            txtCode.Name = "txtCode";
            txtCode.Properties.Appearance.Options.UseTextOptions = true;
            txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtCode.Properties.MaxLength = 100;
            txtCode.Size = new Size(237, 22);
            txtCode.StatusBarAciklama = "Kod Giriniz.";
            txtCode.StyleController = myDataLayoutControl1;
            txtCode.TabIndex = 3;
            txtCode.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
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
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2 });
            Root.Size = new Size(398, 113);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtCode;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(279, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(26, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = tgsIsActive;
            layoutControlItem2.Location = new Point(279, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem2.Size = new Size(99, 31);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtName;
            layoutControlItem3.Location = new Point(0, 31);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem3.Size = new Size(378, 62);
            layoutControlItem3.Text = "İl Adı";
            layoutControlItem3.TextSize = new Size(26, 13);
            // 
            // IlTanimEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "IlTanimEditForm";
            Text = "İl Tanım";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tgsIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyTextEdit txtName;
        private UserControls.Controls.MyToggleSwitch tgsIsActive;
        private UserControls.Controls.MyKodTextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}