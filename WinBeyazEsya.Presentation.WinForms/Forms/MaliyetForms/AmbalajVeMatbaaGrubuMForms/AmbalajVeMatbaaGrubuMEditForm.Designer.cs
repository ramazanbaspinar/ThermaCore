namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajVeMatbaaGrubuMForms
{
    partial class AmbalajVeMatbaaGrubuMEditForm
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
            ((System.ComponentModel.ISupportInitialize)cmbParaBirimi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaliyet.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)glfMalzemeSecimi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // cmbParaBirimi
            // 
            // 
            // txtMaliyet
            // 
            txtMaliyet.Properties.DisplayFormat.FormatString = "n4";
            txtMaliyet.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtMaliyet.Properties.EditFormat.FormatString = "n4";
            txtMaliyet.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtMaliyet.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtMaliyet.Properties.MaskSettings.Set("mask", "n4");
            // 
            // glfMalzemeSecimi
            // 
            // 
            // txtKod
            // 
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(398, 123);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // AmbalajVeMatbaaGrubuMEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            IconOptions.ShowIcon = false;
            Name = "AmbalajVeMatbaaGrubuMEditForm";
            Text = "Ambalaj ve Matbaa Grubu Maliyet Tanýmý";
            ((System.ComponentModel.ISupportInitialize)cmbParaBirimi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMaliyet.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)glfMalzemeSecimi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}


