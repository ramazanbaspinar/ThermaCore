namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.MotorForms
{
    partial class MotorListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotorListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMotorAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMotorTipi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colVolt = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colWatt = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colDevirRpm = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMilUzunlugu = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(814, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnDisariAktar
            // 
            btnDisariAktar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDisariAktar.ImageOptions.SvgImage");
            // 
            // longNavigator1
            // 
            longNavigator1.Dock = DockStyle.Bottom;
            longNavigator1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            longNavigator1.Location = new Point(0, 371);
            longNavigator1.Name = "longNavigator1";
            longNavigator1.Size = new Size(814, 30);
            longNavigator1.TabIndex = 2;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 135);
            myGridControl1.MainView = myGridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(814, 236);
            myGridControl1.TabIndex = 3;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colMotorAdi, colMotorTipi, colVolt, colWatt, colDevirRpm, colMilUzunlugu, colAciklama });
            myGridView1.GridControl = myGridControl1;
            myGridView1.Name = "myGridView1";
            myGridView1.OptionsMenu.EnableColumnMenu = false;
            myGridView1.OptionsMenu.EnableFooterMenu = false;
            myGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            myGridView1.OptionsNavigation.EnterMoveNextColumn = true;
            myGridView1.OptionsPrint.AutoWidth = false;
            myGridView1.OptionsPrint.PrintFooter = false;
            myGridView1.OptionsPrint.PrintGroupFooter = false;
            myGridView1.OptionsView.ColumnAutoWidth = false;
            myGridView1.OptionsView.EnableAppearanceEvenRow = true;
            myGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            myGridView1.OptionsView.ShowAutoFilterRow = true;
            myGridView1.OptionsView.ShowGroupPanel = false;
            myGridView1.OptionsView.ShowViewCaption = true;
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
            myGridView1.ViewCaption = "Motor Tanımları";
            // 
            // colId
            // 
            colId.Caption = "Id";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.OptionsColumn.AllowEdit = false;
            colId.OptionsColumn.ShowInCustomizationForm = false;
            colId.StatusBarAciklama = null;
            colId.StatusBarKisaYol = null;
            colId.StatusBarKisaYolAciklama = null;
            // 
            // colKod
            // 
            colKod.AppearanceCell.Options.UseTextOptions = true;
            colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colKod.Caption = "Kod";
            colKod.FieldName = "Code";
            colKod.Name = "colKod";
            colKod.OptionsColumn.AllowEdit = false;
            colKod.StatusBarAciklama = null;
            colKod.StatusBarKisaYol = null;
            colKod.StatusBarKisaYolAciklama = null;
            colKod.Visible = true;
            colKod.VisibleIndex = 0;
            colKod.Width = 120;
            // 
            // colMotorAdi
            // 
            colMotorAdi.Caption = "Motor Adı";
            colMotorAdi.FieldName = "Name";
            colMotorAdi.Name = "colMotorAdi";
            colMotorAdi.OptionsColumn.AllowEdit = false;
            colMotorAdi.StatusBarAciklama = null;
            colMotorAdi.StatusBarKisaYol = null;
            colMotorAdi.StatusBarKisaYolAciklama = null;
            colMotorAdi.Visible = true;
            colMotorAdi.VisibleIndex = 1;
            colMotorAdi.Width = 150;
            // 
            // colMotorTipi
            // 
            colMotorTipi.Caption = "Motor Tipi";
            colMotorTipi.FieldName = "MotorType";
            colMotorTipi.Name = "colMotorTipi";
            colMotorTipi.OptionsColumn.AllowEdit = false;
            colMotorTipi.StatusBarAciklama = null;
            colMotorTipi.StatusBarKisaYol = null;
            colMotorTipi.StatusBarKisaYolAciklama = null;
            colMotorTipi.Visible = true;
            colMotorTipi.VisibleIndex = 2;
            colMotorTipi.Width = 150;
            // 
            // colVolt
            // 
            colVolt.Caption = "Volt";
            colVolt.FieldName = "Voltage";
            colVolt.Name = "colVolt";
            colVolt.OptionsColumn.AllowEdit = false;
            colVolt.StatusBarAciklama = null;
            colVolt.StatusBarKisaYol = null;
            colVolt.StatusBarKisaYolAciklama = null;
            colVolt.Visible = true;
            colVolt.VisibleIndex = 3;
            colVolt.Width = 150;
            // 
            // colWatt
            // 
            colWatt.Caption = "Watt";
            colWatt.FieldName = "PowerWatt";
            colWatt.Name = "colWatt";
            colWatt.OptionsColumn.AllowEdit = false;
            colWatt.StatusBarAciklama = null;
            colWatt.StatusBarKisaYol = null;
            colWatt.StatusBarKisaYolAciklama = null;
            colWatt.Visible = true;
            colWatt.VisibleIndex = 4;
            colWatt.Width = 150;
            // 
            // colDevirRpm
            // 
            colDevirRpm.Caption = "Devir / Rpm";
            colDevirRpm.FieldName = "Rpm";
            colDevirRpm.Name = "colDevirRpm";
            colDevirRpm.OptionsColumn.AllowEdit = false;
            colDevirRpm.StatusBarAciklama = null;
            colDevirRpm.StatusBarKisaYol = null;
            colDevirRpm.StatusBarKisaYolAciklama = null;
            colDevirRpm.Visible = true;
            colDevirRpm.VisibleIndex = 5;
            colDevirRpm.Width = 150;
            // 
            // colMilUzunlugu
            // 
            colMilUzunlugu.Caption = "Mil Uzunluğu (mm)";
            colMilUzunlugu.FieldName = "Mil Uzunluğu";
            colMilUzunlugu.Name = "colMilUzunlugu";
            colMilUzunlugu.OptionsColumn.AllowEdit = false;
            colMilUzunlugu.StatusBarAciklama = null;
            colMilUzunlugu.StatusBarKisaYol = null;
            colMilUzunlugu.StatusBarKisaYolAciklama = null;
            colMilUzunlugu.Visible = true;
            colMilUzunlugu.VisibleIndex = 6;
            colMilUzunlugu.Width = 150;
            // 
            // colAciklama
            // 
            colAciklama.Caption = "Açıklama";
            colAciklama.FieldName = "Description";
            colAciklama.Name = "colAciklama";
            colAciklama.OptionsColumn.AllowEdit = false;
            colAciklama.StatusBarAciklama = null;
            colAciklama.StatusBarKisaYol = null;
            colAciklama.StatusBarKisaYolAciklama = null;
            colAciklama.Visible = true;
            colAciklama.VisibleIndex = 7;
            colAciklama.Width = 150;
            // 
            // MotorListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "MotorListForm";
            Text = "Motor Tanımları";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(longNavigator1, 0);
            Controls.SetChildIndex(myGridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator longNavigator1;
        private UserControls.Grid.MyGridControl myGridControl1;
        private UserControls.Grid.MyGridView myGridView1;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.Grid.MyGridColumn colMotorAdi;
        private UserControls.Grid.MyGridColumn colMotorTipi;
        private UserControls.Grid.MyGridColumn colVolt;
        private UserControls.Grid.MyGridColumn colWatt;
        private UserControls.Grid.MyGridColumn colDevirRpm;
        private UserControls.Grid.MyGridColumn colMilUzunlugu;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}