namespace WinBeyazEsya.Presentation.WinForms.UserControls
{
    partial class ucBarkodlar
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

        private void InitializeComponent()
        {
            this.gridControlBarcodes = new DevExpress.XtraGrid.GridControl();
            this.gridViewBarcodes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBarcodeValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcodeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPrimary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityPerUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeightPerUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckIsPrimary = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repComboBarcodeType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repComboUnit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repSpinQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repSpinWeight = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnIcBarkodUret = new DevExpress.XtraEditors.SimpleButton();
            this.btnTedarikciBarkoduOku = new DevExpress.XtraEditors.SimpleButton();
            this.btnEtiketYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsPrimary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComboBarcodeType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlBarcodes
            // 
            this.gridControlBarcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlBarcodes.Location = new System.Drawing.Point(0, 40);
            this.gridControlBarcodes.MainView = this.gridViewBarcodes;
            this.gridControlBarcodes.Name = "gridControlBarcodes";
            this.gridControlBarcodes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckIsPrimary,
            this.repComboBarcodeType,
            this.repComboUnit,
            this.repSpinQuantity,
            this.repSpinWeight});
            this.gridControlBarcodes.Size = new System.Drawing.Size(700, 360);
            this.gridControlBarcodes.TabIndex = 0;
            this.gridControlBarcodes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBarcodes});
            // 
            // gridViewBarcodes
            // 
            this.gridViewBarcodes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBarcodeValue,
            this.colBarcodeType,
            this.colUnit,
            this.colQuantityPerUnit,
            this.colWeightPerUnit,
            this.colDescription,
            this.colIsPrimary});
            this.gridViewBarcodes.GridControl = this.gridControlBarcodes;
            this.gridViewBarcodes.Name = "gridViewBarcodes";
            this.gridViewBarcodes.OptionsView.ShowGroupPanel = false;
            // 
            // colBarcodeValue
            // 
            this.colBarcodeValue.Caption = "Barkod Değeri";
            this.colBarcodeValue.FieldName = "BarcodeValue";
            this.colBarcodeValue.Name = "colBarcodeValue";
            this.colBarcodeValue.Visible = true;
            this.colBarcodeValue.VisibleIndex = 0;
            // 
            // colBarcodeType
            // 
            this.colBarcodeType.Caption = "Tipi";
            this.colBarcodeType.ColumnEdit = this.repComboBarcodeType;
            this.colBarcodeType.FieldName = "BarcodeType";
            this.colBarcodeType.Name = "colBarcodeType";
            this.colBarcodeType.Visible = true;
            this.colBarcodeType.VisibleIndex = 1;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Birim";
            this.colUnit.ColumnEdit = this.repComboUnit;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 2;
            // 
            // colQuantityPerUnit
            // 
            this.colQuantityPerUnit.Caption = "Miktar";
            this.colQuantityPerUnit.ColumnEdit = this.repSpinQuantity;
            this.colQuantityPerUnit.FieldName = "QuantityPerUnit";
            this.colQuantityPerUnit.Name = "colQuantityPerUnit";
            this.colQuantityPerUnit.Visible = true;
            this.colQuantityPerUnit.VisibleIndex = 3;
            // 
            // colWeightPerUnit
            // 
            this.colWeightPerUnit.Caption = "Ağırlık (kg)";
            this.colWeightPerUnit.ColumnEdit = this.repSpinWeight;
            this.colWeightPerUnit.FieldName = "WeightPerUnit";
            this.colWeightPerUnit.Name = "colWeightPerUnit";
            this.colWeightPerUnit.ToolTip = "Seçili birimin toplam ağırlığı (kg)";
            this.colWeightPerUnit.Visible = true;
            this.colWeightPerUnit.VisibleIndex = 4;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Açıklama";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            // 
            // colIsPrimary
            // 
            this.colIsPrimary.Caption = "Varsayılan";
            this.colIsPrimary.ColumnEdit = this.repCheckIsPrimary;
            this.colIsPrimary.FieldName = "IsPrimary";
            this.colIsPrimary.Name = "colIsPrimary";
            this.colIsPrimary.Visible = true;
            this.colIsPrimary.VisibleIndex = 6;
            // 
            // repCheckIsPrimary
            // 
            this.repCheckIsPrimary.AutoHeight = false;
            this.repCheckIsPrimary.Name = "repCheckIsPrimary";
            // 
            // repComboBarcodeType
            // 
            this.repComboBarcodeType.AutoHeight = false;
            this.repComboBarcodeType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repComboBarcodeType.Items.AddRange(new object[] {
            "Sistem (Code-128)",
            "Tedarikçi (EAN-13)",
            "Koli Barkodu"});
            this.repComboBarcodeType.Name = "repComboBarcodeType";
            this.repComboBarcodeType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repComboUnit
            // 
            this.repComboUnit.AutoHeight = false;
            this.repComboUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repComboUnit.Items.AddRange(new object[] {
            "Adet",
            "Koli",
            "Palet"});
            this.repComboUnit.Name = "repComboUnit";
            this.repComboUnit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repSpinQuantity
            // 
            this.repSpinQuantity.AutoHeight = false;
            this.repSpinQuantity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinQuantity.Name = "repSpinQuantity";
            // 
            // repSpinWeight
            // 
            this.repSpinWeight.AutoHeight = false;
            this.repSpinWeight.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinWeight.Name = "repSpinWeight";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnIcBarkodUret);
            this.panelControl1.Controls.Add(this.btnTedarikciBarkoduOku);
            this.panelControl1.Controls.Add(this.btnEtiketYazdir);
            this.panelControl1.Controls.Add(this.btnSil);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(600, 40);
            this.panelControl1.TabIndex = 1;
            // 
            // btnIcBarkodUret
            // 
            this.btnIcBarkodUret.Location = new System.Drawing.Point(12, 8);
            this.btnIcBarkodUret.Name = "btnIcBarkodUret";
            this.btnIcBarkodUret.Size = new System.Drawing.Size(120, 23);
            this.btnIcBarkodUret.TabIndex = 0;
            this.btnIcBarkodUret.Text = "İç Barkod Üret";
            this.btnIcBarkodUret.Click += new System.EventHandler(this.btnIcBarkodUret_Click);
            // 
            // btnTedarikciBarkoduOku
            // 
            this.btnTedarikciBarkoduOku.Location = new System.Drawing.Point(138, 8);
            this.btnTedarikciBarkoduOku.Name = "btnTedarikciBarkoduOku";
            this.btnTedarikciBarkoduOku.Size = new System.Drawing.Size(150, 23);
            this.btnTedarikciBarkoduOku.TabIndex = 1;
            this.btnTedarikciBarkoduOku.Text = "Tedarikçi Barkodu Oku";
            this.btnTedarikciBarkoduOku.Click += new System.EventHandler(this.btnTedarikciBarkoduOku_Click);
            // 
            // btnEtiketYazdir
            // 
            this.btnEtiketYazdir.Location = new System.Drawing.Point(294, 8);
            this.btnEtiketYazdir.Name = "btnEtiketYazdir";
            this.btnEtiketYazdir.Size = new System.Drawing.Size(100, 23);
            this.btnEtiketYazdir.TabIndex = 2;
            this.btnEtiketYazdir.Text = "Etiket Yazdır";
            this.btnEtiketYazdir.Click += new System.EventHandler(this.btnEtiketYazdir_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(400, 8);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // ucBarkodlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlBarcodes);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucBarkodlar";
            this.Size = new System.Drawing.Size(600, 400);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsPrimary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComboBarcodeType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl gridControlBarcodes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBarcodes;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeValue;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPrimary;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityPerUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightPerUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckIsPrimary;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repComboBarcodeType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repComboUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinWeight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnIcBarkodUret;
        private DevExpress.XtraEditors.SimpleButton btnTedarikciBarkoduOku;
        private DevExpress.XtraEditors.SimpleButton btnEtiketYazdir;
        private DevExpress.XtraEditors.SimpleButton btnSil;
    }
}

