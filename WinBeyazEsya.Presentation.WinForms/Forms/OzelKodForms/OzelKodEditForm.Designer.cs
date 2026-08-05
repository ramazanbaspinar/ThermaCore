namespace WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms
{
    partial class OzelKodEditForm
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
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            txtAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            txtOzelKodAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            txtKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtOzelKodAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(398, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtOzelKodAdi);
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 140);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(84, 74);
            txtAciklama.MenuManager = ribbon;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Properties.MaxLength = 500;
            txtAciklama.Size = new Size(302, 54);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 2;
            txtAciklama.Tag = "Description";
            // 
            // txtOzelKodAdi
            // 
            txtOzelKodAdi.EnterMoveNextControl = true;
            txtOzelKodAdi.Location = new Point(84, 43);
            txtOzelKodAdi.MenuManager = ribbon;
            txtOzelKodAdi.Name = "txtOzelKodAdi";
            txtOzelKodAdi.Properties.MaxLength = 100;
            txtOzelKodAdi.Size = new Size(302, 20);
            txtOzelKodAdi.StatusBarAciklama = "";
            txtOzelKodAdi.StyleController = myDataLayoutControl1;
            txtOzelKodAdi.TabIndex = 1;
            txtOzelKodAdi.Tag = "Name";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(84, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(302, 20);
            txtKod.StatusBarAciklama = "";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 0;
            txtKod.Tag = "Code";
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
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3 });
            Root.Size = new Size(398, 140);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(378, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(60, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtOzelKodAdi;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(378, 31);
            layoutControlItem2.Text = "Özel Kod Adı";
            layoutControlItem2.TextSize = new Size(60, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtAciklama;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 58);
            layoutControlItem3.Text = "Açıklama";
            layoutControlItem3.TextSize = new Size(60, 13);
            // 
            // OzelKodEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "OzelKodEditForm";
            Text = "Özel Kod Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtOzelKodAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.MyMemoEdit txtAciklama;
        private UserControls.Controls.MyTextEdit txtOzelKodAdi;
        private UserControls.Controls.MyTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
