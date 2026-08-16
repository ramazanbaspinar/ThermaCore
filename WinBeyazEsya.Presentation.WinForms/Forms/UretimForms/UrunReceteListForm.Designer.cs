namespace WinBeyazEsya.Presentation.WinForms.Forms.UretimForms
{
    partial class UrunReceteListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunReceteListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colReceteAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMamul = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colRevizyonNo = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTarih = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colNetMalzemeTutari = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colToplamReceteMaliyeti = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(806, 153);
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
            longNavigator1.Location = new Point(0, 364);
            longNavigator1.Name = "longNavigator1";
            longNavigator1.Size = new Size(806, 30);
            longNavigator1.TabIndex = 2;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 153);
            myGridControl1.MainView = myGridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(806, 211);
            myGridControl1.TabIndex = 3;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colReceteAdi, colMamul, colTarih, colNetMalzemeTutari, colToplamReceteMaliyeti, colAciklama, colRevizyonNo });
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
            myGridView1.ViewCaption = "Ürün Reçeteleri";
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
            // colReceteAdi
            // 
            colReceteAdi.Caption = "Reçete Adı";
            colReceteAdi.FieldName = "Name";
            colReceteAdi.Name = "colReceteAdi";
            colReceteAdi.OptionsColumn.AllowEdit = false;
            colReceteAdi.StatusBarAciklama = null;
            colReceteAdi.StatusBarKisaYol = null;
            colReceteAdi.StatusBarKisaYolAciklama = null;
            colReceteAdi.Visible = true;
            colReceteAdi.VisibleIndex = 1;
            colReceteAdi.Width = 150;
            // 
            // colMamul
            // 
            colMamul.Caption = "Mamül";
            colMamul.FieldName = "FinishedGoodName";
            colMamul.Name = "colMamul";
            colMamul.OptionsColumn.AllowEdit = false;
            colMamul.StatusBarAciklama = null;
            colMamul.StatusBarKisaYol = null;
            colMamul.StatusBarKisaYolAciklama = null;
            colMamul.Visible = true;
            colMamul.VisibleIndex = 2;
            colMamul.Width = 150;
            // 
            // colRevizyonNo
            // 
            colRevizyonNo.Caption = "Revizyon No";
            colRevizyonNo.FieldName = "RevisionNumber";
            colRevizyonNo.Name = "colRevizyonNo";
            colRevizyonNo.OptionsColumn.AllowEdit = false;
            colRevizyonNo.StatusBarAciklama = null;
            colRevizyonNo.StatusBarKisaYol = null;
            colRevizyonNo.StatusBarKisaYolAciklama = null;
            colRevizyonNo.Visible = true;
            colRevizyonNo.VisibleIndex = 7;
            // 
            // colTarih
            // 
            colTarih.Caption = "Tarih";
            colTarih.FieldName = "Date";
            colTarih.Name = "colTarih";
            colTarih.OptionsColumn.AllowEdit = false;
            colTarih.StatusBarAciklama = null;
            colTarih.StatusBarKisaYol = null;
            colTarih.StatusBarKisaYolAciklama = null;
            colTarih.Visible = true;
            colTarih.VisibleIndex = 3;
            colTarih.Width = 150;
            // 
            // colNetMalzemeTutari
            // 
            colNetMalzemeTutari.Caption = "Net Malzeme Tutarı";
            colNetMalzemeTutari.DisplayFormat.FormatString = "n4";
            colNetMalzemeTutari.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colNetMalzemeTutari.FieldName = "NetMaterialCost";
            colNetMalzemeTutari.GroupFormat.FormatString = "n4";
            colNetMalzemeTutari.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colNetMalzemeTutari.Name = "colNetMalzemeTutari";
            colNetMalzemeTutari.OptionsColumn.AllowEdit = false;
            colNetMalzemeTutari.StatusBarAciklama = null;
            colNetMalzemeTutari.StatusBarKisaYol = null;
            colNetMalzemeTutari.StatusBarKisaYolAciklama = null;
            colNetMalzemeTutari.Visible = true;
            colNetMalzemeTutari.VisibleIndex = 4;
            colNetMalzemeTutari.Width = 150;
            // 
            // colToplamReceteMaliyeti
            // 
            colToplamReceteMaliyeti.Caption = "Toplam Reçete Maliyeti";
            colToplamReceteMaliyeti.DisplayFormat.FormatString = "n4";
            colToplamReceteMaliyeti.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colToplamReceteMaliyeti.FieldName = "TotalCost";
            colToplamReceteMaliyeti.GroupFormat.FormatString = "n4";
            colToplamReceteMaliyeti.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colToplamReceteMaliyeti.Name = "colToplamReceteMaliyeti";
            colToplamReceteMaliyeti.OptionsColumn.AllowEdit = false;
            colToplamReceteMaliyeti.StatusBarAciklama = null;
            colToplamReceteMaliyeti.StatusBarKisaYol = null;
            colToplamReceteMaliyeti.StatusBarKisaYolAciklama = null;
            colToplamReceteMaliyeti.Visible = true;
            colToplamReceteMaliyeti.VisibleIndex = 5;
            colToplamReceteMaliyeti.Width = 150;
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
            // UrunReceteListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "UrunReceteListForm";
            Text = "Ürün Reçeteleri";
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
        private UserControls.Grid.MyGridColumn colReceteAdi;
        private UserControls.Grid.MyGridColumn colRevizyonNo;
        private UserControls.Grid.MyGridColumn colTarih;
        private UserControls.Grid.MyGridColumn colNetMalzemeTutari;
        private UserControls.Grid.MyGridColumn colAciklama;
        private UserControls.Grid.MyGridColumn colMamul;
        private UserControls.Grid.MyGridColumn colToplamReceteMaliyeti;
    }
}