namespace ThermaCore.Presentation.WinForms.Forms.KodYonetimForms
{
    partial class KodLogEditForm
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
            txtSonKodDegeri = new ThermaCore.Presentation.WinForms.UserControls.Controls.MySpinEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSonKodDegeri.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(323, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(txtSonKodDegeri);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(323, 90);
            myDataLayoutControl1.TabIndex = 2;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtSonKodDegeri
            // 
            txtSonKodDegeri.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtSonKodDegeri.EnterMoveNextControl = true;
            txtSonKodDegeri.Location = new Point(105, 12);
            txtSonKodDegeri.MenuManager = ribbon;
            txtSonKodDegeri.Name = "txtSonKodDegeri";
            txtSonKodDegeri.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtSonKodDegeri.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtSonKodDegeri.Properties.Appearance.Options.UseFont = true;
            txtSonKodDegeri.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtSonKodDegeri.Properties.AppearanceDisabled.Options.UseFont = true;
            txtSonKodDegeri.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtSonKodDegeri.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtSonKodDegeri.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtSonKodDegeri.Properties.AppearanceFocused.Options.UseFont = true;
            txtSonKodDegeri.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtSonKodDegeri.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtSonKodDegeri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtSonKodDegeri.Properties.MaskSettings.Set("mask", "n0");
            txtSonKodDegeri.Size = new Size(206, 22);
            txtSonKodDegeri.StatusBarAciklama = null;
            txtSonKodDegeri.StyleController = myDataLayoutControl1;
            txtSonKodDegeri.TabIndex = 4;
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
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1 });
            Root.Size = new Size(323, 90);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtSonKodDegeri;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(303, 70);
            layoutControlItem1.Text = "Son Kod Değeri";
            layoutControlItem1.TextSize = new Size(81, 15);
            // 
            // KodLogEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 249);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(325, 250);
            Name = "KodLogEditForm";
            Text = "Kod Log Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtSonKodDegeri.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MySpinEdit txtSonKodDegeri;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}