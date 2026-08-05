namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms
{
    partial class GenelGiderEditForm
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
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            cmbParaBirimi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyComboBoxEdit();
            txtGenelGiderMaliyeti = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyCalcEdit();
            txtGenelGider = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            txtKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbParaBirimi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGenelGiderMaliyeti.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGenelGider.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
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
            myDataLayoutControl1.Controls.Add(cmbParaBirimi);
            myDataLayoutControl1.Controls.Add(txtGenelGiderMaliyeti);
            myDataLayoutControl1.Controls.Add(txtGenelGider);
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
            // cmbParaBirimi
            // 
            cmbParaBirimi.EnterMoveNextControl = true;
            cmbParaBirimi.Location = new Point(118, 105);
            cmbParaBirimi.MenuManager = ribbon;
            cmbParaBirimi.Name = "cmbParaBirimi";
            cmbParaBirimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbParaBirimi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbParaBirimi.Size = new Size(251, 20);
            cmbParaBirimi.StatusBarAciklama = "";
            cmbParaBirimi.StatusBarKisaYol = "F4 :";
            cmbParaBirimi.StatusBarKisaYolAciklama = "";
            cmbParaBirimi.StyleController = myDataLayoutControl1;
            cmbParaBirimi.TabIndex = 2;
            cmbParaBirimi.Tag = "CurrencyId";
            // 
            // txtGenelGiderMaliyeti
            // 
            txtGenelGiderMaliyeti.EnterMoveNextControl = true;
            txtGenelGiderMaliyeti.Location = new Point(118, 74);
            txtGenelGiderMaliyeti.MenuManager = ribbon;
            txtGenelGiderMaliyeti.Name = "txtGenelGiderMaliyeti";
            txtGenelGiderMaliyeti.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtGenelGiderMaliyeti.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtGenelGiderMaliyeti.Properties.DisplayFormat.FormatString = "n4";
            txtGenelGiderMaliyeti.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtGenelGiderMaliyeti.Properties.EditFormat.FormatString = "n4";
            txtGenelGiderMaliyeti.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtGenelGiderMaliyeti.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtGenelGiderMaliyeti.Properties.MaskSettings.Set("mask", "n4");
            txtGenelGiderMaliyeti.Size = new Size(251, 20);
            txtGenelGiderMaliyeti.StatusBarAciklama = null;
            txtGenelGiderMaliyeti.StatusBarKisaYol = "F4 :";
            txtGenelGiderMaliyeti.StatusBarKisaYolAciklama = "Hesap Makinesi";
            txtGenelGiderMaliyeti.StyleController = myDataLayoutControl1;
            txtGenelGiderMaliyeti.TabIndex = 1;
            txtGenelGiderMaliyeti.Tag = "Cost";
            // 
            // txtGenelGider
            // 
            txtGenelGider.EnterMoveNextControl = true;
            txtGenelGider.Location = new Point(118, 43);
            txtGenelGider.MenuManager = ribbon;
            txtGenelGider.Name = "txtGenelGider";
            txtGenelGider.Properties.MaxLength = 100;
            txtGenelGider.Size = new Size(251, 20);
            txtGenelGider.StatusBarAciklama = "";
            txtGenelGider.StyleController = myDataLayoutControl1;
            txtGenelGider.TabIndex = 0;
            txtGenelGider.Tag = "Name";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(118, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(251, 20);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 3;
            txtKod.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
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
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(381, 144);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(361, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(94, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtGenelGider;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(361, 31);
            layoutControlItem2.Text = "Genel Gider";
            layoutControlItem2.TextSize = new Size(94, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtGenelGiderMaliyeti;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(361, 31);
            layoutControlItem3.Text = "Genel Gider Maliyeti";
            layoutControlItem3.TextSize = new Size(94, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = cmbParaBirimi;
            layoutControlItem4.Location = new Point(0, 93);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(361, 31);
            layoutControlItem4.Text = "Para Birimi";
            layoutControlItem4.TextSize = new Size(94, 13);
            // 
            // GenelGiderEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "GenelGiderEditForm";
            Text = "Genel Gider Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbParaBirimi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGenelGiderMaliyeti.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGenelGider.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyComboBoxEdit cmbParaBirimi;
        private UserControls.Controls.MyCalcEdit txtGenelGiderMaliyeti;
        private UserControls.Controls.MyTextEdit txtGenelGider;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
