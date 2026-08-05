namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms
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
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            rowVadeFarkiOrani = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            rowFireOrani = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            rowOrtalamaUretimDegeri = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)propertyGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(407, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(propertyGridControl1);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(407, 232);
            myDataLayoutControl1.TabIndex = 2;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // propertyGridControl1
            // 
            propertyGridControl1.Location = new Point(12, 12);
            propertyGridControl1.MenuManager = ribbon;
            propertyGridControl1.Name = "propertyGridControl1";
            propertyGridControl1.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            propertyGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { rowVadeFarkiOrani, rowFireOrani, rowOrtalamaUretimDegeri });
            propertyGridControl1.Size = new Size(383, 208);
            propertyGridControl1.TabIndex = 4;
            // 
            // rowVadeFarkiOrani
            // 
            rowVadeFarkiOrani.Name = "rowVadeFarkiOrani";
            rowVadeFarkiOrani.Properties.Caption = "Vade Farkı Oranı (%)";
            rowVadeFarkiOrani.Properties.DisplayFormat.FormatString = "N2";
            rowVadeFarkiOrani.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rowVadeFarkiOrani.Properties.FieldName = "MaturityDifferenceRate";
            rowVadeFarkiOrani.Properties.UnboundDataType = typeof(decimal);
            // 
            // rowFireOrani
            // 
            rowFireOrani.Name = "rowFireOrani";
            rowFireOrani.Properties.Caption = "Fire Oranı (%)";
            rowFireOrani.Properties.DisplayFormat.FormatString = "n2";
            rowFireOrani.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rowFireOrani.Properties.FieldName = "WastageRate";
            rowFireOrani.Properties.UnboundDataType = typeof(decimal);
            // 
            // rowOrtalamaUretimDegeri
            // 
            rowOrtalamaUretimDegeri.Name = "rowOrtalamaUretimDegeri";
            rowOrtalamaUretimDegeri.Properties.Caption = "Ortalama Üretim Değeri (Adet)";
            rowOrtalamaUretimDegeri.Properties.DisplayFormat.FormatString = "n0";
            rowOrtalamaUretimDegeri.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rowOrtalamaUretimDegeri.Properties.FieldName = "AverageProductionValue";
            rowOrtalamaUretimDegeri.Properties.UnboundDataType = typeof(decimal);
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1 });
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1 });
            Root.Size = new Size(407, 232);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = propertyGridControl1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(387, 212);
            layoutControlItem1.TextVisible = false;
            // 
            // MaliyetParametreEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 391);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            Name = "MaliyetParametreEditForm";
            Text = "Maliyet Parametreleri Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)propertyGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowVadeFarkiOrani;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowFireOrani;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOrtalamaUretimDegeri;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}