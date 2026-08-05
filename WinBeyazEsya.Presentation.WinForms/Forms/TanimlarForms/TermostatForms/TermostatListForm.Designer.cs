namespace WinBeyazEsya.Presentation.WinForms.Forms.TermostatForms
{
    partial class TermostatListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermostatListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTermostatAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMinSicaklik = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMaxSicaklik = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAmperAkimDerecesi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKilcalBoruKuyrukBoyu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colTermostatAdi, colMinSicaklik, colMaxSicaklik, colAmperAkimDerecesi, colKilcalBoruKuyrukBoyu, colAciklama });
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
            myGridView1.ViewCaption = "Termostat Tanımları";
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
            // colTermostatAdi
            // 
            colTermostatAdi.Caption = "Termostat Adı";
            colTermostatAdi.FieldName = "Name";
            colTermostatAdi.Name = "colTermostatAdi";
            colTermostatAdi.OptionsColumn.AllowEdit = false;
            colTermostatAdi.StatusBarAciklama = null;
            colTermostatAdi.StatusBarKisaYol = null;
            colTermostatAdi.StatusBarKisaYolAciklama = null;
            colTermostatAdi.Visible = true;
            colTermostatAdi.VisibleIndex = 1;
            colTermostatAdi.Width = 150;
            // 
            // colMinSicaklik
            // 
            colMinSicaklik.Caption = "Min. Sıcaklık";
            colMinSicaklik.FieldName = "MinTemperature";
            colMinSicaklik.Name = "colMinSicaklik";
            colMinSicaklik.OptionsColumn.AllowEdit = false;
            colMinSicaklik.StatusBarAciklama = null;
            colMinSicaklik.StatusBarKisaYol = null;
            colMinSicaklik.StatusBarKisaYolAciklama = null;
            colMinSicaklik.Visible = true;
            colMinSicaklik.VisibleIndex = 2;
            colMinSicaklik.Width = 150;
            // 
            // colMaxSicaklik
            // 
            colMaxSicaklik.Caption = "Max. Sıcaklık";
            colMaxSicaklik.FieldName = "MaxTemperature";
            colMaxSicaklik.Name = "colMaxSicaklik";
            colMaxSicaklik.OptionsColumn.AllowEdit = false;
            colMaxSicaklik.StatusBarAciklama = null;
            colMaxSicaklik.StatusBarKisaYol = null;
            colMaxSicaklik.StatusBarKisaYolAciklama = null;
            colMaxSicaklik.Visible = true;
            colMaxSicaklik.VisibleIndex = 3;
            colMaxSicaklik.Width = 150;
            // 
            // colAmperAkimDerecesi
            // 
            colAmperAkimDerecesi.Caption = "Amper / Akım Derecesi";
            colAmperAkimDerecesi.FieldName = "CurrentAmper";
            colAmperAkimDerecesi.Name = "colAmperAkimDerecesi";
            colAmperAkimDerecesi.OptionsColumn.AllowEdit = false;
            colAmperAkimDerecesi.StatusBarAciklama = null;
            colAmperAkimDerecesi.StatusBarKisaYol = null;
            colAmperAkimDerecesi.StatusBarKisaYolAciklama = null;
            colAmperAkimDerecesi.Visible = true;
            colAmperAkimDerecesi.VisibleIndex = 4;
            colAmperAkimDerecesi.Width = 150;
            // 
            // colKilcalBoruKuyrukBoyu
            // 
            colKilcalBoruKuyrukBoyu.Caption = "Kılcal Boru / Kuyruk Boyu";
            colKilcalBoruKuyrukBoyu.FieldName = "CapillaryLengthMm";
            colKilcalBoruKuyrukBoyu.Name = "colKilcalBoruKuyrukBoyu";
            colKilcalBoruKuyrukBoyu.OptionsColumn.AllowEdit = false;
            colKilcalBoruKuyrukBoyu.StatusBarAciklama = null;
            colKilcalBoruKuyrukBoyu.StatusBarKisaYol = null;
            colKilcalBoruKuyrukBoyu.StatusBarKisaYolAciklama = null;
            colKilcalBoruKuyrukBoyu.Visible = true;
            colKilcalBoruKuyrukBoyu.VisibleIndex = 5;
            colKilcalBoruKuyrukBoyu.Width = 150;
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
            colAciklama.VisibleIndex = 6;
            colAciklama.Width = 150;
            // 
            // TermostatListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "TermostatListForm";
            Text = "Termostat Tanımları";
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
        private UserControls.Grid.MyGridColumn colTermostatAdi;
        private UserControls.Grid.MyGridColumn colMinSicaklik;
        private UserControls.Grid.MyGridColumn colMaxSicaklik;
        private UserControls.Grid.MyGridColumn colAmperAkimDerecesi;
        private UserControls.Grid.MyGridColumn colKilcalBoruKuyrukBoyu;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}
