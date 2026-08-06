namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms
{
    partial class MaliyetParametreEditForm
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
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            txtVadeFarkiOrani = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyCalcEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            txtFireOrani = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyCalcEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            txtOrtalamaUretimDegeri = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MySpinEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVadeFarkiOrani.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFireOrani.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtOrtalamaUretimDegeri.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(399, 123);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(txtOrtalamaUretimDegeri);
            myDataLayoutControl1.Controls.Add(txtFireOrani);
            myDataLayoutControl1.Controls.Add(txtVadeFarkiOrani);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 123);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(399, 235);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
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
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3 });
            Root.Size = new Size(399, 235);
            Root.TextVisible = false;
            // 
            // txtVadeFarkiOrani
            // 
            txtVadeFarkiOrani.EnterMoveNextControl = true;
            txtVadeFarkiOrani.Location = new Point(162, 12);
            txtVadeFarkiOrani.MenuManager = ribbon;
            txtVadeFarkiOrani.Name = "txtVadeFarkiOrani";
            txtVadeFarkiOrani.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtVadeFarkiOrani.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtVadeFarkiOrani.Properties.DisplayFormat.FormatString = "n2";
            txtVadeFarkiOrani.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtVadeFarkiOrani.Properties.EditFormat.FormatString = "n2";
            txtVadeFarkiOrani.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtVadeFarkiOrani.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtVadeFarkiOrani.Properties.MaskSettings.Set("mask", "n2");
            txtVadeFarkiOrani.Size = new Size(225, 20);
            txtVadeFarkiOrani.StatusBarAciklama = null;
            txtVadeFarkiOrani.StatusBarKisaYol = "F4 :";
            txtVadeFarkiOrani.StatusBarKisaYolAciklama = "Hesap Makinesi";
            txtVadeFarkiOrani.StyleController = myDataLayoutControl1;
            txtVadeFarkiOrani.TabIndex = 0;
            txtVadeFarkiOrani.Tag = "MaturityDifferenceRate";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtVadeFarkiOrani;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(379, 31);
            layoutControlItem1.Text = "Vade Farkı Oranı (%)";
            layoutControlItem1.TextSize = new Size(146, 13);
            // 
            // txtFireOrani
            // 
            txtFireOrani.EnterMoveNextControl = true;
            txtFireOrani.Location = new Point(162, 43);
            txtFireOrani.MenuManager = ribbon;
            txtFireOrani.Name = "txtFireOrani";
            txtFireOrani.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtFireOrani.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFireOrani.Properties.DisplayFormat.FormatString = "n2";
            txtFireOrani.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtFireOrani.Properties.EditFormat.FormatString = "n2";
            txtFireOrani.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtFireOrani.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtFireOrani.Properties.MaskSettings.Set("mask", "n2");
            txtFireOrani.Size = new Size(225, 20);
            txtFireOrani.StatusBarAciklama = null;
            txtFireOrani.StatusBarKisaYol = "F4 :";
            txtFireOrani.StatusBarKisaYolAciklama = "Hesap Makinesi";
            txtFireOrani.StyleController = myDataLayoutControl1;
            txtFireOrani.TabIndex = 1;
            txtFireOrani.Tag = "WastageRate";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtFireOrani;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(379, 31);
            layoutControlItem2.Text = "Fire Oranı (%)";
            layoutControlItem2.TextSize = new Size(146, 13);
            // 
            // txtOrtalamaUretimDegeri
            // 
            txtOrtalamaUretimDegeri.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOrtalamaUretimDegeri.EnterMoveNextControl = true;
            txtOrtalamaUretimDegeri.Location = new Point(162, 74);
            txtOrtalamaUretimDegeri.MenuManager = ribbon;
            txtOrtalamaUretimDegeri.Name = "txtOrtalamaUretimDegeri";
            txtOrtalamaUretimDegeri.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtOrtalamaUretimDegeri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtOrtalamaUretimDegeri.Properties.DisplayFormat.FormatString = "n0";
            txtOrtalamaUretimDegeri.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOrtalamaUretimDegeri.Properties.EditFormat.FormatString = "n0";
            txtOrtalamaUretimDegeri.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOrtalamaUretimDegeri.Properties.MaskSettings.Set("mask", "n0");
            txtOrtalamaUretimDegeri.Size = new Size(225, 20);
            txtOrtalamaUretimDegeri.StatusBarAciklama = "";
            txtOrtalamaUretimDegeri.StyleController = myDataLayoutControl1;
            txtOrtalamaUretimDegeri.TabIndex = 2;
            txtOrtalamaUretimDegeri.Tag = "AverageProductionValue";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtOrtalamaUretimDegeri;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(379, 153);
            layoutControlItem3.Text = "Ortalama Üretim Değeri (Adet)";
            layoutControlItem3.TextSize = new Size(146, 13);
            // 
            // MaliyetParametreEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 391);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            Name = "MaliyetParametreEditForm";
            Text = "Maliyet Parametreleri Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVadeFarkiOrani.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFireOrani.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtOrtalamaUretimDegeri.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.MySpinEdit txtOrtalamaUretimDegeri;
        private UserControls.Controls.MyCalcEdit txtFireOrani;
        private UserControls.Controls.MyCalcEdit txtVadeFarkiOrani;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
