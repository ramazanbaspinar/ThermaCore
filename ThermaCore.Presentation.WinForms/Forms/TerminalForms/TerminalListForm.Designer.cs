namespace ThermaCore.Presentation.WinForms.Forms.TerminalForms
{
    partial class TerminalListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCihazAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colEthernetMacAddress = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colIpAdresi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colWifiMacAddress = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colVpnMacAddress = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Appearance.Empty.BackColor = Color.WhiteSmoke;
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colCihazAdi, colEthernetMacAddress, colWifiMacAddress, colVpnMacAddress, colIpAdresi, colAciklama });
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
            myGridView1.ViewCaption = "Terminaller";
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
            // colCihazAdi
            // 
            colCihazAdi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colCihazAdi.AppearanceCell.Options.UseFont = true;
            colCihazAdi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colCihazAdi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colCihazAdi.AppearanceHeader.ForeColor = Color.White;
            colCihazAdi.AppearanceHeader.Options.UseBackColor = true;
            colCihazAdi.AppearanceHeader.Options.UseFont = true;
            colCihazAdi.AppearanceHeader.Options.UseForeColor = true;
            colCihazAdi.Caption = "Cihaz Adı";
            colCihazAdi.FieldName = "DeviceName";
            colCihazAdi.Name = "colCihazAdi";
            colCihazAdi.OptionsColumn.AllowEdit = false;
            colCihazAdi.StatusBarAciklama = null;
            colCihazAdi.StatusBarKisaYol = null;
            colCihazAdi.StatusBarKisaYolAciklama = null;
            colCihazAdi.Visible = true;
            colCihazAdi.VisibleIndex = 0;
            colCihazAdi.Width = 175;
            // 
            // colEthernetMacAddress
            // 
            colEthernetMacAddress.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colEthernetMacAddress.AppearanceCell.Options.UseFont = true;
            colEthernetMacAddress.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colEthernetMacAddress.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colEthernetMacAddress.AppearanceHeader.ForeColor = Color.White;
            colEthernetMacAddress.AppearanceHeader.Options.UseBackColor = true;
            colEthernetMacAddress.AppearanceHeader.Options.UseFont = true;
            colEthernetMacAddress.AppearanceHeader.Options.UseForeColor = true;
            colEthernetMacAddress.Caption = "Ethernet Mac Adresi";
            colEthernetMacAddress.FieldName = "EthernetMacAddress";
            colEthernetMacAddress.Name = "colEthernetMacAddress";
            colEthernetMacAddress.OptionsColumn.AllowEdit = false;
            colEthernetMacAddress.StatusBarAciklama = null;
            colEthernetMacAddress.StatusBarKisaYol = null;
            colEthernetMacAddress.StatusBarKisaYolAciklama = null;
            colEthernetMacAddress.Visible = true;
            colEthernetMacAddress.VisibleIndex = 1;
            colEthernetMacAddress.Width = 175;
            // 
            // colIpAdresi
            // 
            colIpAdresi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colIpAdresi.AppearanceCell.Options.UseFont = true;
            colIpAdresi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colIpAdresi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colIpAdresi.AppearanceHeader.ForeColor = Color.White;
            colIpAdresi.AppearanceHeader.Options.UseBackColor = true;
            colIpAdresi.AppearanceHeader.Options.UseFont = true;
            colIpAdresi.AppearanceHeader.Options.UseForeColor = true;
            colIpAdresi.Caption = "IP Adresi";
            colIpAdresi.FieldName = "IpAddress";
            colIpAdresi.Name = "colIpAdresi";
            colIpAdresi.OptionsColumn.AllowEdit = false;
            colIpAdresi.StatusBarAciklama = null;
            colIpAdresi.StatusBarKisaYol = null;
            colIpAdresi.StatusBarKisaYolAciklama = null;
            colIpAdresi.Visible = true;
            colIpAdresi.VisibleIndex = 4;
            colIpAdresi.Width = 175;
            // 
            // colAciklama
            // 
            colAciklama.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colAciklama.AppearanceCell.Options.UseFont = true;
            colAciklama.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colAciklama.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colAciklama.AppearanceHeader.ForeColor = Color.White;
            colAciklama.AppearanceHeader.Options.UseBackColor = true;
            colAciklama.AppearanceHeader.Options.UseFont = true;
            colAciklama.AppearanceHeader.Options.UseForeColor = true;
            colAciklama.Caption = "Açıklama";
            colAciklama.FieldName = "Description";
            colAciklama.Name = "colAciklama";
            colAciklama.OptionsColumn.AllowEdit = false;
            colAciklama.StatusBarAciklama = null;
            colAciklama.StatusBarKisaYol = null;
            colAciklama.StatusBarKisaYolAciklama = null;
            colAciklama.Visible = true;
            colAciklama.VisibleIndex = 5;
            colAciklama.Width = 175;
            // 
            // colWifiMacAddress
            // 
            colWifiMacAddress.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colWifiMacAddress.AppearanceCell.Options.UseFont = true;
            colWifiMacAddress.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colWifiMacAddress.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colWifiMacAddress.AppearanceHeader.ForeColor = Color.White;
            colWifiMacAddress.AppearanceHeader.Options.UseBackColor = true;
            colWifiMacAddress.AppearanceHeader.Options.UseFont = true;
            colWifiMacAddress.AppearanceHeader.Options.UseForeColor = true;
            colWifiMacAddress.Caption = "Wifi Mac Adresi";
            colWifiMacAddress.FieldName = "WifiMacAddress";
            colWifiMacAddress.Name = "colWifiMacAddress";
            colWifiMacAddress.OptionsColumn.AllowEdit = false;
            colWifiMacAddress.StatusBarAciklama = null;
            colWifiMacAddress.StatusBarKisaYol = null;
            colWifiMacAddress.StatusBarKisaYolAciklama = null;
            colWifiMacAddress.Visible = true;
            colWifiMacAddress.VisibleIndex = 2;
            colWifiMacAddress.Width = 175;
            // 
            // colVpnMacAddress
            // 
            colVpnMacAddress.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colVpnMacAddress.AppearanceCell.Options.UseFont = true;
            colVpnMacAddress.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colVpnMacAddress.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colVpnMacAddress.AppearanceHeader.ForeColor = Color.White;
            colVpnMacAddress.AppearanceHeader.Options.UseBackColor = true;
            colVpnMacAddress.AppearanceHeader.Options.UseFont = true;
            colVpnMacAddress.AppearanceHeader.Options.UseForeColor = true;
            colVpnMacAddress.Caption = "Vpn Mac Adresi";
            colVpnMacAddress.FieldName = "VpnMacAddress";
            colVpnMacAddress.Name = "colVpnMacAddress";
            colVpnMacAddress.OptionsColumn.AllowEdit = false;
            colVpnMacAddress.StatusBarAciklama = null;
            colVpnMacAddress.StatusBarKisaYol = null;
            colVpnMacAddress.StatusBarKisaYolAciklama = null;
            colVpnMacAddress.Visible = true;
            colVpnMacAddress.VisibleIndex = 3;
            colVpnMacAddress.Width = 175;
            // 
            // TerminalListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "TerminalListForm";
            Text = "Terminaller";
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
        private UserControls.Grid.MyGridColumn colCihazAdi;
        private UserControls.Grid.MyGridColumn colEthernetMacAddress;
        private UserControls.Grid.MyGridColumn colIpAdresi;
        private UserControls.Grid.MyGridColumn colAciklama;
        private UserControls.Grid.MyGridColumn colWifiMacAddress;
        private UserControls.Grid.MyGridColumn colVpnMacAddress;
    }
}