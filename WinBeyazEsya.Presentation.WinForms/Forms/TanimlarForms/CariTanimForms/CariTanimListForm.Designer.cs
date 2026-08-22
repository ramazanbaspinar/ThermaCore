namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms
{
    partial class CariTanimListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CariTanimListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCariUnvani = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colYetkiliKisi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colUlke = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colIl = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colIlce = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTelefon1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTelefon2 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGSM = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colVergiDairesi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colVergiTcKimlikNo = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colEPosta = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colOzelKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCariTipi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(711, 135);
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
            longNavigator1.Location = new Point(0, 387);
            longNavigator1.Name = "longNavigator1";
            longNavigator1.Size = new Size(711, 30);
            longNavigator1.TabIndex = 2;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 135);
            myGridControl1.MainView = myGridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(711, 252);
            myGridControl1.TabIndex = 3;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colCariUnvani, colYetkiliKisi, colUlke, colIl, colIlce, colTelefon1, colTelefon2, colGSM, colVergiDairesi, colVergiTcKimlikNo, colEPosta, colOzelKod, colCariTipi });
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
            myGridView1.ViewCaption = "Cari Tanımlar";
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
            // colCariUnvani
            // 
            colCariUnvani.Caption = "Cari Unvanı";
            colCariUnvani.FieldName = "Title";
            colCariUnvani.Name = "colCariUnvani";
            colCariUnvani.OptionsColumn.AllowEdit = false;
            colCariUnvani.StatusBarAciklama = null;
            colCariUnvani.StatusBarKisaYol = null;
            colCariUnvani.StatusBarKisaYolAciklama = null;
            colCariUnvani.Visible = true;
            colCariUnvani.VisibleIndex = 1;
            colCariUnvani.Width = 125;
            // 
            // colYetkiliKisi
            // 
            colYetkiliKisi.Caption = "Yetkili Kişi";
            colYetkiliKisi.FieldName = "InCharge";
            colYetkiliKisi.Name = "colYetkiliKisi";
            colYetkiliKisi.OptionsColumn.AllowEdit = false;
            colYetkiliKisi.StatusBarAciklama = null;
            colYetkiliKisi.StatusBarKisaYol = null;
            colYetkiliKisi.StatusBarKisaYolAciklama = null;
            colYetkiliKisi.Visible = true;
            colYetkiliKisi.VisibleIndex = 2;
            colYetkiliKisi.Width = 125;
            // 
            // colUlke
            // 
            colUlke.Caption = "Ülke";
            colUlke.FieldName = "CountryName";
            colUlke.Name = "colUlke";
            colUlke.OptionsColumn.AllowEdit = false;
            colUlke.StatusBarAciklama = null;
            colUlke.StatusBarKisaYol = null;
            colUlke.StatusBarKisaYolAciklama = null;
            colUlke.Visible = true;
            colUlke.VisibleIndex = 3;
            colUlke.Width = 125;
            // 
            // colIl
            // 
            colIl.Caption = "İl";
            colIl.FieldName = "CityName";
            colIl.Name = "colIl";
            colIl.OptionsColumn.AllowEdit = false;
            colIl.StatusBarAciklama = null;
            colIl.StatusBarKisaYol = null;
            colIl.StatusBarKisaYolAciklama = null;
            colIl.Visible = true;
            colIl.VisibleIndex = 4;
            colIl.Width = 125;
            // 
            // colIlce
            // 
            colIlce.Caption = "İlçe";
            colIlce.FieldName = "TownName";
            colIlce.Name = "colIlce";
            colIlce.OptionsColumn.AllowEdit = false;
            colIlce.StatusBarAciklama = null;
            colIlce.StatusBarKisaYol = null;
            colIlce.StatusBarKisaYolAciklama = null;
            colIlce.Visible = true;
            colIlce.VisibleIndex = 5;
            colIlce.Width = 125;
            // 
            // colTelefon1
            // 
            colTelefon1.Caption = "Telefon-1";
            colTelefon1.FieldName = "TelNrs1";
            colTelefon1.Name = "colTelefon1";
            colTelefon1.OptionsColumn.AllowEdit = false;
            colTelefon1.StatusBarAciklama = null;
            colTelefon1.StatusBarKisaYol = null;
            colTelefon1.StatusBarKisaYolAciklama = null;
            colTelefon1.Visible = true;
            colTelefon1.VisibleIndex = 6;
            colTelefon1.Width = 125;
            // 
            // colTelefon2
            // 
            colTelefon2.Caption = "Telefon-2";
            colTelefon2.FieldName = "TelNrs2";
            colTelefon2.Name = "colTelefon2";
            colTelefon2.OptionsColumn.AllowEdit = false;
            colTelefon2.StatusBarAciklama = null;
            colTelefon2.StatusBarKisaYol = null;
            colTelefon2.StatusBarKisaYolAciklama = null;
            colTelefon2.Visible = true;
            colTelefon2.VisibleIndex = 7;
            colTelefon2.Width = 125;
            // 
            // colGSM
            // 
            colGSM.Caption = "GSM (Cep Telefonu)";
            colGSM.FieldName = "CellPhone";
            colGSM.Name = "colGSM";
            colGSM.OptionsColumn.AllowEdit = false;
            colGSM.StatusBarAciklama = null;
            colGSM.StatusBarKisaYol = null;
            colGSM.StatusBarKisaYolAciklama = null;
            colGSM.Visible = true;
            colGSM.VisibleIndex = 8;
            colGSM.Width = 125;
            // 
            // colVergiDairesi
            // 
            colVergiDairesi.Caption = "Vergi Dairesi";
            colVergiDairesi.FieldName = "TaxOffice";
            colVergiDairesi.Name = "colVergiDairesi";
            colVergiDairesi.OptionsColumn.AllowEdit = false;
            colVergiDairesi.StatusBarAciklama = null;
            colVergiDairesi.StatusBarKisaYol = null;
            colVergiDairesi.StatusBarKisaYolAciklama = null;
            colVergiDairesi.Visible = true;
            colVergiDairesi.VisibleIndex = 9;
            colVergiDairesi.Width = 125;
            // 
            // colVergiTcKimlikNo
            // 
            colVergiTcKimlikNo.Caption = "Vergi/TC Kimlik No";
            colVergiTcKimlikNo.FieldName = "TaxNr";
            colVergiTcKimlikNo.Name = "colVergiTcKimlikNo";
            colVergiTcKimlikNo.OptionsColumn.AllowEdit = false;
            colVergiTcKimlikNo.StatusBarAciklama = null;
            colVergiTcKimlikNo.StatusBarKisaYol = null;
            colVergiTcKimlikNo.StatusBarKisaYolAciklama = null;
            colVergiTcKimlikNo.Visible = true;
            colVergiTcKimlikNo.VisibleIndex = 10;
            colVergiTcKimlikNo.Width = 125;
            // 
            // colEPosta
            // 
            colEPosta.Caption = "E-Posta";
            colEPosta.FieldName = "EmailAddr";
            colEPosta.Name = "colEPosta";
            colEPosta.OptionsColumn.AllowEdit = false;
            colEPosta.StatusBarAciklama = null;
            colEPosta.StatusBarKisaYol = null;
            colEPosta.StatusBarKisaYolAciklama = null;
            colEPosta.Visible = true;
            colEPosta.VisibleIndex = 11;
            colEPosta.Width = 125;
            // 
            // colOzelKod
            // 
            colOzelKod.Caption = "Özel Kod";
            colOzelKod.FieldName = "SpeCode";
            colOzelKod.Name = "colOzelKod";
            colOzelKod.OptionsColumn.AllowEdit = false;
            colOzelKod.StatusBarAciklama = null;
            colOzelKod.StatusBarKisaYol = null;
            colOzelKod.StatusBarKisaYolAciklama = null;
            colOzelKod.Visible = true;
            colOzelKod.VisibleIndex = 12;
            colOzelKod.Width = 125;
            // 
            // colCariTipi
            // 
            colCariTipi.Caption = "Cari Tipi";
            colCariTipi.FieldName = "CardType";
            colCariTipi.Name = "colCariTipi";
            colCariTipi.OptionsColumn.AllowEdit = false;
            colCariTipi.StatusBarAciklama = null;
            colCariTipi.StatusBarKisaYol = null;
            colCariTipi.StatusBarKisaYolAciklama = null;
            colCariTipi.Visible = true;
            colCariTipi.VisibleIndex = 13;
            colCariTipi.Width = 125;
            // 
            // CariTanimListForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 441);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "CariTanimListForm";
            Text = "Cari Tanımlar";
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
        private UserControls.Grid.MyGridColumn colCariTipi;
        private UserControls.Grid.MyGridColumn colCariUnvani;
        private UserControls.Grid.MyGridColumn colOzelKod;
        private UserControls.Grid.MyGridColumn colYetkiliKisi;
        private UserControls.Grid.MyGridColumn colUlke;
        private UserControls.Grid.MyGridColumn colIl;
        private UserControls.Grid.MyGridColumn colIlce;
        private UserControls.Grid.MyGridColumn colTelefon1;
        private UserControls.Grid.MyGridColumn colVergiDairesi;
        private UserControls.Grid.MyGridColumn colVergiTcKimlikNo;
        private UserControls.Grid.MyGridColumn colEPosta;
        private UserControls.Grid.MyGridColumn colTelefon2;
        private UserControls.Grid.MyGridColumn colGSM;
    }
}