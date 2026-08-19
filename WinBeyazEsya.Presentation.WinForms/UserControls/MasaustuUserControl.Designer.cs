namespace WinBeyazEsya.Presentation.WinForms.UserControls
{
    partial class MasaustuUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.tileControl = new DevExpress.XtraEditors.TileControl();
            this.grpFavoriler = new DevExpress.XtraEditors.TileGroup();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchControl
            // 
            this.searchControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchControl.Location = new System.Drawing.Point(260, 40);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.searchControl.Properties.Appearance.Options.UseFont = true;
            this.searchControl.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(227)))));
            this.searchControl.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.searchControl.Properties.AutoHeight = false;
            this.searchControl.Properties.ShowClearButton = true;
            this.searchControl.Properties.ShowSearchButton = true;
            this.searchControl.Properties.NullValuePrompt = "Tüm sistemde arama yapın... (Menüler ve Tanımlar)";
            this.searchControl.Size = new System.Drawing.Size(600, 45);
            this.searchControl.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(260, 85); // Arama çubuğunun biraz altında
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Hızlı Erişim (Favoriler)";
            // 
            // tileControl
            // 
            this.tileControl.AllowDrag = false;
            this.tileControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            
            // 🚨 GRİ BLOĞU YOK ETME PROTOKOLÜ (Nükleer Çözüm)
            this.tileControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tileControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.tileControl.BackColor = System.Drawing.Color.Transparent;
            
            // 🚨 UCUZ İMLEÇ İPTALİ: Kurumsal default fare oku
            this.tileControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileControl.BackColor = System.Drawing.Color.Transparent;
            
            // 🚨 TILECONTROL SCROLL GARANTİSİ
            this.tileControl.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollBar;
            
            // 🚨 İKİNCİ GÜVENLİK KATMANI
            this.tileControl.BackgroundImage = global::WinBeyazEsya.Presentation.WinForms.Properties.Resources.winbeyazesya_arkaplan;
            this.tileControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            
            this.tileControl.IndentBetweenItems = 20;
            this.tileControl.IndentBetweenGroups = 20;
            
            // 🚨 TILEITEM GERÇEK GLASSMORPHISM
            this.tileControl.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tileControl.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileControl.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tileControl.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileControl.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileControl.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileControl.AppearanceItem.Normal.Options.UseFont = true;
            this.tileControl.AppearanceItem.Normal.Options.UseForeColor = true;
            
            this.tileControl.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tileControl.AppearanceItem.Hovered.BorderColor = System.Drawing.Color.Transparent;
            this.tileControl.AppearanceItem.Hovered.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tileControl.AppearanceItem.Hovered.ForeColor = System.Drawing.Color.White;
            this.tileControl.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileControl.AppearanceItem.Hovered.Options.UseBorderColor = true;
            this.tileControl.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileControl.AppearanceItem.Hovered.Options.UseForeColor = true;
            
            this.tileControl.Groups.Add(this.grpFavoriler);
            
            this.tileControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControl.Location = new System.Drawing.Point(50, 120);
            this.tileControl.Margin = new System.Windows.Forms.Padding(50);
            this.tileControl.Padding = new System.Windows.Forms.Padding(30);
            this.tileControl.MaxId = 1;
            this.tileControl.Name = "tileControl";
            this.tileControl.Size = new System.Drawing.Size(900, 430);
            this.tileControl.TabIndex = 1;
            this.tileControl.Text = "tileControl";
            // 
            // grpFavoriler
            // 
            this.grpFavoriler.Name = "grpFavoriler";
            this.grpFavoriler.Text = "Hızlı Kısayollarım";
            // 
            // MasaustuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            this.BackgroundImage = global::WinBeyazEsya.Presentation.WinForms.Properties.Resources.winbeyazesya_arkaplan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackColor = System.Drawing.Color.Transparent;
            
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.searchControl);
            this.Controls.Add(this.tileControl);
            this.Name = "MasaustuUserControl";
            this.Size = new System.Drawing.Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SearchControl searchControl;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.TileControl tileControl;
        private DevExpress.XtraEditors.TileGroup grpFavoriler;
    }
}
