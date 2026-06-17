namespace RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators
{
    partial class LongNavigator
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LongNavigator));
            this.Navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // Navigator
            // 
            this.Navigator.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Navigator.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Navigator.Appearance.Options.UseFont = true;
            this.Navigator.Appearance.Options.UseForeColor = true;
            this.Navigator.Buttons.Append.Visible = false;
            this.Navigator.Buttons.CancelEdit.Visible = false;
            this.Navigator.Buttons.Edit.Visible = false;
            this.Navigator.Buttons.EndEdit.Visible = false;
            this.Navigator.Buttons.First.ImageIndex = 0;
            this.Navigator.Buttons.ImageList = this.imageCollection;
            this.Navigator.Buttons.Last.ImageIndex = 5;
            this.Navigator.Buttons.Next.ImageIndex = 3;
            this.Navigator.Buttons.NextPage.ImageIndex = 4;
            this.Navigator.Buttons.Prev.ImageIndex = 2;
            this.Navigator.Buttons.PrevPage.ImageIndex = 1;
            this.Navigator.Buttons.Remove.Visible = false;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Navigator.Location = new System.Drawing.Point(0, 0);
            this.Navigator.Name = "Navigator";
            this.Navigator.ShowToolTips = true;
            this.Navigator.Size = new System.Drawing.Size(534, 30);
            this.Navigator.TabIndex = 0;
            this.Navigator.Text = "controlNavigator1";
            this.Navigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.Navigator.TextStringFormat = "Kayıtlar ( {0} / {1} )";
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(global::ThermaCore.Presentation.WinForms.Properties.Resources.first_16x16, "first_16x16", typeof(global::ThermaCore.Presentation.WinForms.Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "first_16x16");
            this.imageCollection.InsertImage(global::ThermaCore.Presentation.WinForms.Properties.Resources.doubleprev_16x16, "doubleprev_16x16", typeof(global::ThermaCore.Presentation.WinForms.Properties.Resources), 1);
            this.imageCollection.Images.SetKeyName(1, "doubleprev_16x16");
            this.imageCollection.InsertImage(global::ThermaCore.Presentation.WinForms.Properties.Resources.prev_16x16, "prev_16x16", typeof(global::ThermaCore.Presentation.WinForms.Properties.Resources), 2);
            this.imageCollection.Images.SetKeyName(2, "prev_16x16");
            this.imageCollection.InsertImage(global::ThermaCore.Presentation.WinForms.Properties.Resources.next_16x16, "next_16x16", typeof(global::ThermaCore.Presentation.WinForms.Properties.Resources), 3);
            this.imageCollection.Images.SetKeyName(3, "next_16x16");
            this.imageCollection.InsertImage(global::ThermaCore.Presentation.WinForms.Properties.Resources.doublenext_16x16, "doublenext_16x16", typeof(global::ThermaCore.Presentation.WinForms.Properties.Resources), 4);
            this.imageCollection.Images.SetKeyName(4, "doublenext_16x16");
            this.imageCollection.InsertImage(global::ThermaCore.Presentation.WinForms.Properties.Resources.last_16x16, "last_16x16", typeof(global::ThermaCore.Presentation.WinForms.Properties.Resources), 5);
            this.imageCollection.Images.SetKeyName(5, "last_16x16");
            // 
            // LongNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Navigator);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "LongNavigator";
            this.Size = new System.Drawing.Size(534, 30);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imageCollection;
        public DevExpress.XtraEditors.ControlNavigator Navigator;
    }
}
