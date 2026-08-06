namespace WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms
{
    partial class KodSablonlariListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KodSablonlariListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colModul = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKodOnEk = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKodSonEk = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSayisalUzunluk = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBaslangicSayisi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colOtomatikKodUretimi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colModul, colKodOnEk, colKodSonEk, colSayisalUzunluk, colBaslangicSayisi, colOtomatikKodUretimi });
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
            myGridView1.ViewCaption = "Kod Şablonları";
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
            // colModul
            // 
            colModul.Caption = "Modül";
            colModul.FieldName = "Module";
            colModul.Name = "colModul";
            colModul.OptionsColumn.AllowEdit = false;
            colModul.StatusBarAciklama = null;
            colModul.StatusBarKisaYol = null;
            colModul.StatusBarKisaYolAciklama = null;
            colModul.Visible = true;
            colModul.VisibleIndex = 0;
            colModul.Width = 125;
            // 
            // colKodOnEk
            // 
            colKodOnEk.Caption = "Kod Ön Ek";
            colKodOnEk.FieldName = "CodePrefix";
            colKodOnEk.Name = "colKodOnEk";
            colKodOnEk.OptionsColumn.AllowEdit = false;
            colKodOnEk.StatusBarAciklama = null;
            colKodOnEk.StatusBarKisaYol = null;
            colKodOnEk.StatusBarKisaYolAciklama = null;
            colKodOnEk.Visible = true;
            colKodOnEk.VisibleIndex = 1;
            colKodOnEk.Width = 125;
            // 
            // colKodSonEk
            // 
            colKodSonEk.Caption = "Kod Son Ek";
            colKodSonEk.FieldName = "CodeSuffix";
            colKodSonEk.Name = "colKodSonEk";
            colKodSonEk.OptionsColumn.AllowEdit = false;
            colKodSonEk.StatusBarAciklama = null;
            colKodSonEk.StatusBarKisaYol = null;
            colKodSonEk.StatusBarKisaYolAciklama = null;
            colKodSonEk.Visible = true;
            colKodSonEk.VisibleIndex = 2;
            colKodSonEk.Width = 125;
            // 
            // colSayisalUzunluk
            // 
            colSayisalUzunluk.Caption = "Sayısal Uzunluk";
            colSayisalUzunluk.FieldName = "NumericLength";
            colSayisalUzunluk.Name = "colSayisalUzunluk";
            colSayisalUzunluk.OptionsColumn.AllowEdit = false;
            colSayisalUzunluk.StatusBarAciklama = null;
            colSayisalUzunluk.StatusBarKisaYol = null;
            colSayisalUzunluk.StatusBarKisaYolAciklama = null;
            colSayisalUzunluk.Visible = true;
            colSayisalUzunluk.VisibleIndex = 3;
            colSayisalUzunluk.Width = 125;
            // 
            // colBaslangicSayisi
            // 
            colBaslangicSayisi.Caption = "Başlangıç Sayısı";
            colBaslangicSayisi.FieldName = "StartNumber";
            colBaslangicSayisi.Name = "colBaslangicSayisi";
            colBaslangicSayisi.OptionsColumn.AllowEdit = false;
            colBaslangicSayisi.StatusBarAciklama = null;
            colBaslangicSayisi.StatusBarKisaYol = null;
            colBaslangicSayisi.StatusBarKisaYolAciklama = null;
            colBaslangicSayisi.Visible = true;
            colBaslangicSayisi.VisibleIndex = 4;
            colBaslangicSayisi.Width = 125;
            // 
            // colOtomatikKodUretimi
            // 
            colOtomatikKodUretimi.Caption = "Otomatik Kod Üretimi";
            colOtomatikKodUretimi.FieldName = "IsAutoCodeGenerationEnabled";
            colOtomatikKodUretimi.Name = "colOtomatikKodUretimi";
            colOtomatikKodUretimi.OptionsColumn.AllowEdit = false;
            colOtomatikKodUretimi.StatusBarAciklama = null;
            colOtomatikKodUretimi.StatusBarKisaYol = null;
            colOtomatikKodUretimi.StatusBarKisaYolAciklama = null;
            colOtomatikKodUretimi.Visible = true;
            colOtomatikKodUretimi.VisibleIndex = 5;
            colOtomatikKodUretimi.Width = 125;
            // 
            // CodeTemplateListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "CodeTemplateListForm";
            Text = "Kod Şablonları";
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
        private UserControls.Grid.MyGridColumn colModul;
        private UserControls.Grid.MyGridColumn colKodOnEk;
        private UserControls.Grid.MyGridColumn colKodSonEk;
        private UserControls.Grid.MyGridColumn colSayisalUzunluk;
        private UserControls.Grid.MyGridColumn colBaslangicSayisi;
        private UserControls.Grid.MyGridColumn colOtomatikKodUretimi;
    }
}

