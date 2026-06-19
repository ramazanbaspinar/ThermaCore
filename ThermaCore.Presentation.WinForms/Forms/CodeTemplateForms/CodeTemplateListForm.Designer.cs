namespace ThermaCore.Presentation.WinForms.Forms.CodeTemplateForms
{
    partial class CodeTemplateListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeTemplateListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colModul = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKodOnEk = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKodSonEk = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSayisalUzunluk = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBaslangicSayisi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colOtomatikKodUretimi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Appearance.Empty.BackColor = Color.FromArgb(245, 245, 245);
            myGridView1.Appearance.Empty.Font = new Font("Segoe UI", 9.75F);
            myGridView1.Appearance.Empty.Options.UseBackColor = true;
            myGridView1.Appearance.Empty.Options.UseFont = true;
            myGridView1.Appearance.EvenRow.BackColor = Color.FromArgb(250, 250, 250);
            myGridView1.Appearance.EvenRow.Options.UseBackColor = true;
            myGridView1.Appearance.FocusedCell.BackColor = Color.FromArgb(255, 249, 219);
            myGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            myGridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 249, 219);
            myGridView1.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            myGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            myGridView1.Appearance.FocusedRow.Options.UseFont = true;
            myGridView1.Appearance.FooterPanel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            myGridView1.Appearance.FooterPanel.ForeColor = Color.FromArgb(64, 64, 64);
            myGridView1.Appearance.FooterPanel.Options.UseFont = true;
            myGridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            myGridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(46, 134, 193);
            myGridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            myGridView1.Appearance.HeaderPanel.ForeColor = Color.White;
            myGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            myGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            myGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            myGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            myGridView1.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 249, 219);
            myGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            myGridView1.Appearance.OddRow.BackColor = Color.White;
            myGridView1.Appearance.OddRow.Options.UseBackColor = true;
            myGridView1.Appearance.Row.BackColor = Color.White;
            myGridView1.Appearance.Row.Font = new Font("Segoe UI", 9.75F);
            myGridView1.Appearance.Row.ForeColor = Color.Black;
            myGridView1.Appearance.Row.Options.UseBackColor = true;
            myGridView1.Appearance.Row.Options.UseFont = true;
            myGridView1.Appearance.Row.Options.UseForeColor = true;
            myGridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(204, 229, 255);
            myGridView1.Appearance.SelectedRow.ForeColor = Color.Black;
            myGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            myGridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            myGridView1.Appearance.ViewCaption.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            myGridView1.Appearance.ViewCaption.ForeColor = Color.FromArgb(64, 64, 64);
            myGridView1.Appearance.ViewCaption.Options.UseFont = true;
            myGridView1.Appearance.ViewCaption.Options.UseForeColor = true;
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
            myGridView1.OptionsView.EnableAppearanceOddRow = true;
            myGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            myGridView1.OptionsView.RowAutoHeight = true;
            myGridView1.OptionsView.ShowAutoFilterRow = true;
            myGridView1.OptionsView.ShowGroupPanel = false;
            myGridView1.OptionsView.ShowViewCaption = true;
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
            myGridView1.ViewCaption = "Kod Þablonlarý";
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
            colModul.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colModul.AppearanceCell.Options.UseFont = true;
            colModul.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colModul.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colModul.AppearanceHeader.ForeColor = Color.White;
            colModul.AppearanceHeader.Options.UseBackColor = true;
            colModul.AppearanceHeader.Options.UseFont = true;
            colModul.AppearanceHeader.Options.UseForeColor = true;
            colModul.Caption = "Modül";
            colModul.FieldName = "Module";
            colModul.Name = "colModul";
            colModul.OptionsColumn.AllowEdit = false;
            colModul.StatusBarAciklama = null;
            colModul.StatusBarKisaYol = null;
            colModul.StatusBarKisaYolAciklama = null;
            colModul.Visible = true;
            colModul.VisibleIndex = 0;
            colModul.Width = 175;
            // 
            // colKodOnEk
            // 
            colKodOnEk.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colKodOnEk.AppearanceCell.Options.UseFont = true;
            colKodOnEk.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colKodOnEk.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colKodOnEk.AppearanceHeader.ForeColor = Color.White;
            colKodOnEk.AppearanceHeader.Options.UseBackColor = true;
            colKodOnEk.AppearanceHeader.Options.UseFont = true;
            colKodOnEk.AppearanceHeader.Options.UseForeColor = true;
            colKodOnEk.Caption = "Kod Ön Ek";
            colKodOnEk.FieldName = "CodePrefix";
            colKodOnEk.Name = "colKodOnEk";
            colKodOnEk.OptionsColumn.AllowEdit = false;
            colKodOnEk.StatusBarAciklama = null;
            colKodOnEk.StatusBarKisaYol = null;
            colKodOnEk.StatusBarKisaYolAciklama = null;
            colKodOnEk.Visible = true;
            colKodOnEk.VisibleIndex = 1;
            colKodOnEk.Width = 175;
            // 
            // colKodSonEk
            // 
            colKodSonEk.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colKodSonEk.AppearanceCell.Options.UseFont = true;
            colKodSonEk.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colKodSonEk.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colKodSonEk.AppearanceHeader.ForeColor = Color.White;
            colKodSonEk.AppearanceHeader.Options.UseBackColor = true;
            colKodSonEk.AppearanceHeader.Options.UseFont = true;
            colKodSonEk.AppearanceHeader.Options.UseForeColor = true;
            colKodSonEk.Caption = "Kod Son Ek";
            colKodSonEk.FieldName = "CodeSuffix";
            colKodSonEk.Name = "colKodSonEk";
            colKodSonEk.OptionsColumn.AllowEdit = false;
            colKodSonEk.StatusBarAciklama = null;
            colKodSonEk.StatusBarKisaYol = null;
            colKodSonEk.StatusBarKisaYolAciklama = null;
            colKodSonEk.Visible = true;
            colKodSonEk.VisibleIndex = 2;
            colKodSonEk.Width = 175;
            // 
            // colSayisalUzunluk
            // 
            colSayisalUzunluk.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colSayisalUzunluk.AppearanceCell.Options.UseFont = true;
            colSayisalUzunluk.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colSayisalUzunluk.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colSayisalUzunluk.AppearanceHeader.ForeColor = Color.White;
            colSayisalUzunluk.AppearanceHeader.Options.UseBackColor = true;
            colSayisalUzunluk.AppearanceHeader.Options.UseFont = true;
            colSayisalUzunluk.AppearanceHeader.Options.UseForeColor = true;
            colSayisalUzunluk.Caption = "Sayýsal Uzunluk";
            colSayisalUzunluk.FieldName = "NumericLength";
            colSayisalUzunluk.Name = "colSayisalUzunluk";
            colSayisalUzunluk.OptionsColumn.AllowEdit = false;
            colSayisalUzunluk.StatusBarAciklama = null;
            colSayisalUzunluk.StatusBarKisaYol = null;
            colSayisalUzunluk.StatusBarKisaYolAciklama = null;
            colSayisalUzunluk.Visible = true;
            colSayisalUzunluk.VisibleIndex = 3;
            colSayisalUzunluk.Width = 175;
            // 
            // colBaslangicSayisi
            // 
            colBaslangicSayisi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colBaslangicSayisi.AppearanceCell.Options.UseFont = true;
            colBaslangicSayisi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colBaslangicSayisi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colBaslangicSayisi.AppearanceHeader.ForeColor = Color.White;
            colBaslangicSayisi.AppearanceHeader.Options.UseBackColor = true;
            colBaslangicSayisi.AppearanceHeader.Options.UseFont = true;
            colBaslangicSayisi.AppearanceHeader.Options.UseForeColor = true;
            colBaslangicSayisi.Caption = "Baþlangýç Sayýsý";
            colBaslangicSayisi.FieldName = "StartNumber";
            colBaslangicSayisi.Name = "colBaslangicSayisi";
            colBaslangicSayisi.OptionsColumn.AllowEdit = false;
            colBaslangicSayisi.StatusBarAciklama = null;
            colBaslangicSayisi.StatusBarKisaYol = null;
            colBaslangicSayisi.StatusBarKisaYolAciklama = null;
            colBaslangicSayisi.Visible = true;
            colBaslangicSayisi.VisibleIndex = 4;
            colBaslangicSayisi.Width = 175;
            // 
            // colOtomatikKodUretimi
            // 
            colOtomatikKodUretimi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colOtomatikKodUretimi.AppearanceCell.Options.UseFont = true;
            colOtomatikKodUretimi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colOtomatikKodUretimi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colOtomatikKodUretimi.AppearanceHeader.ForeColor = Color.White;
            colOtomatikKodUretimi.AppearanceHeader.Options.UseBackColor = true;
            colOtomatikKodUretimi.AppearanceHeader.Options.UseFont = true;
            colOtomatikKodUretimi.AppearanceHeader.Options.UseForeColor = true;
            colOtomatikKodUretimi.Caption = "Otomatik Kod Üretimi";
            colOtomatikKodUretimi.FieldName = "IsAutoCodeGenerationEnabled";
            colOtomatikKodUretimi.Name = "colOtomatikKodUretimi";
            colOtomatikKodUretimi.OptionsColumn.AllowEdit = false;
            colOtomatikKodUretimi.StatusBarAciklama = null;
            colOtomatikKodUretimi.StatusBarKisaYol = null;
            colOtomatikKodUretimi.StatusBarKisaYolAciklama = null;
            colOtomatikKodUretimi.Visible = true;
            colOtomatikKodUretimi.VisibleIndex = 5;
            colOtomatikKodUretimi.Width = 175;
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
            Text = "Kod Þablonlarý";
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
