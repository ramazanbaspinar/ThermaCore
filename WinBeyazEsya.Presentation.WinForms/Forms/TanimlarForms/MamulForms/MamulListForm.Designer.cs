namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms
{
    partial class MamulListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MamulListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMamulAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMalzemeGrubu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSatisFiyati = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSatisKdv = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colMamulAdi, colMalzemeGrubu, colSatisFiyati, colSatisKdv, colAciklama });
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
            myGridView1.ViewCaption = "Ürün (Mamül) Tanımları";
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
            // colMamulAdi
            // 
            colMamulAdi.Caption = "Mamül Adı";
            colMamulAdi.FieldName = "Name";
            colMamulAdi.Name = "colMamulAdi";
            colMamulAdi.OptionsColumn.AllowEdit = false;
            colMamulAdi.StatusBarAciklama = null;
            colMamulAdi.StatusBarKisaYol = null;
            colMamulAdi.StatusBarKisaYolAciklama = null;
            colMamulAdi.Visible = true;
            colMamulAdi.VisibleIndex = 1;
            colMamulAdi.Width = 150;
            // 
            // colMalzemeGrubu
            // 
            colMalzemeGrubu.Caption = "Malzeme Grubu";
            colMalzemeGrubu.FieldName = "GroupName";
            colMalzemeGrubu.Name = "colMalzemeGrubu";
            colMalzemeGrubu.OptionsColumn.AllowEdit = false;
            colMalzemeGrubu.StatusBarAciklama = null;
            colMalzemeGrubu.StatusBarKisaYol = null;
            colMalzemeGrubu.StatusBarKisaYolAciklama = null;
            colMalzemeGrubu.Visible = true;
            colMalzemeGrubu.VisibleIndex = 2;
            colMalzemeGrubu.Width = 150;
            // 
            // colSatisFiyati
            // 
            colSatisFiyati.Caption = "Satış Fiyatı";
            colSatisFiyati.FieldName = "SalesPrice";
            colSatisFiyati.Name = "colSatisFiyati";
            colSatisFiyati.OptionsColumn.AllowEdit = false;
            colSatisFiyati.StatusBarAciklama = null;
            colSatisFiyati.StatusBarKisaYol = null;
            colSatisFiyati.StatusBarKisaYolAciklama = null;
            colSatisFiyati.Visible = true;
            colSatisFiyati.VisibleIndex = 3;
            colSatisFiyati.Width = 150;
            // 
            // colSatisKdv
            // 
            colSatisKdv.Caption = "Satış KDV (%)";
            colSatisKdv.FieldName = "SalesVatRate";
            colSatisKdv.Name = "colSatisKdv";
            colSatisKdv.OptionsColumn.AllowEdit = false;
            colSatisKdv.StatusBarAciklama = null;
            colSatisKdv.StatusBarKisaYol = null;
            colSatisKdv.StatusBarKisaYolAciklama = null;
            colSatisKdv.Visible = true;
            colSatisKdv.VisibleIndex = 4;
            colSatisKdv.Width = 150;
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
            colAciklama.VisibleIndex = 5;
            colAciklama.Width = 150;
            // 
            // MamulListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "MamulListForm";
            Text = "Ürün (Mamül) Tanımları";
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
        private UserControls.Grid.MyGridColumn colMamulAdi;
        private UserControls.Grid.MyGridColumn colMalzemeGrubu;
        private UserControls.Grid.MyGridColumn colSatisFiyati;
        private UserControls.Grid.MyGridColumn colSatisKdv;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}