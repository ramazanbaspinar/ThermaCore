using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Presentation.WinForms.UserControls
{
    public partial class ucBarkodlar : XtraUserControl
    {
        private IItemBarcodeService _itemBarcodeService;
        private AutoMapper.IMapper _mapper;
        private BindingList<ItemBarcodeListDto> _barcodes = new BindingList<ItemBarcodeListDto>();

        public long CurrentRecordId { get; set; }
        public string CurrentRecordCode { get; set; }
        public ModuleType CurrentModuleType { get; set; }

        public ucBarkodlar()
        {
            InitializeComponent();
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try { _mapper = Program.ServiceProvider.GetRequiredService<AutoMapper.IMapper>(); } catch { }
            }
        }

        private DevExpress.XtraEditors.SimpleButton btnManuelBarkodEkle;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                gridControlBarcodes.DataSource = _barcodes;
                
                gridViewBarcodes.ShowingEditor += GridViewBarcodes_ShowingEditor;
                gridViewBarcodes.CellValueChanged += GridViewBarcodes_CellValueChanged;
                
                _barcodes.ListChanged += (s, e) => SetDirty(true);

                // Add btnManuelBarkodEkle programmatically
                btnManuelBarkodEkle = new DevExpress.XtraEditors.SimpleButton();
                btnManuelBarkodEkle.Text = "Manuel Barkod Ekle";
                btnManuelBarkodEkle.Size = new Size(130, 23);
                btnManuelBarkodEkle.Location = new Point(btnTedarikciBarkoduOku.Right + 6, btnTedarikciBarkoduOku.Top);
                btnManuelBarkodEkle.Click += btnManuelBarkodEkle_Click;
                
                // Shift others
                btnEtiketYazdir.Left = btnManuelBarkodEkle.Right + 6;
                btnSil.Left = btnEtiketYazdir.Right + 6;
                
                panelControl1.Controls.Add(btnManuelBarkodEkle);

                // Add "Manuel / Legacy" to repository item types if not present
                var rep = (DevExpress.XtraEditors.Repository.RepositoryItemComboBox)gridViewBarcodes.Columns["BarcodeType"].ColumnEdit;
                if (!rep.Items.Contains("Manuel / Legacy"))
                {
                    rep.Items.Add("Manuel / Legacy");
                }
                
                if (!rep.Items.Contains("Sistem (EAN-13)"))
                {
                    rep.Items.Add("Sistem (EAN-13)");
                }
            }
        }

        private void GridViewBarcodes_ShowingEditor(object sender, CancelEventArgs e)
        {
            // Tipi hücresi her koşulda kilitli
            if (gridViewBarcodes.FocusedColumn.FieldName == "BarcodeType")
            {
                e.Cancel = true;
                return;
            }

            var row = gridViewBarcodes.GetFocusedRow() as ItemBarcodeListDto;
            if (row != null && (row.BarcodeType == "Sistem (Code-128)" || row.BarcodeType == "Sistem (EAN-13)"))
            {
                // Sistem barkodu ise bu alanlar kilitli
                if (gridViewBarcodes.FocusedColumn.FieldName == "BarcodeValue" ||
                    gridViewBarcodes.FocusedColumn.FieldName == "Unit" ||
                    gridViewBarcodes.FocusedColumn.FieldName == "QuantityPerUnit" ||
                    gridViewBarcodes.FocusedColumn.FieldName == "WeightPerUnit")
                {
                    e.Cancel = true;
                }
            }
        }

        private void GridViewBarcodes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SetDirty(true);

            if (e.Column.FieldName == "IsPrimary")
            {
                bool isChecked = (bool)e.Value;
                if (isChecked)
                {
                    var currentRow = gridViewBarcodes.GetRow(e.RowHandle) as ItemBarcodeListDto;
                    foreach (var item in _barcodes)
                    {
                        if (item != currentRow && item.IsPrimary)
                        {
                            item.IsPrimary = false;
                        }
                    }
                    gridViewBarcodes.RefreshData();
                }
            }
        }

        public void Yukle(long recordId, string recordCode, ModuleType moduleType)
        {
            CurrentRecordId = recordId;
            CurrentRecordCode = recordCode;
            CurrentModuleType = moduleType;
            
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            if (_itemBarcodeService != null && CurrentRecordId > 0)
            {
                var data = _itemBarcodeService.GetBarcodes(CurrentRecordId, CurrentModuleType);
                _barcodes = new BindingList<ItemBarcodeListDto>(data);
                _barcodes.ListChanged += (s, e) => SetDirty(true);
                gridControlBarcodes.DataSource = _barcodes;
            }
            else
            {
                _barcodes.Clear();
            }
            SetDirty(false);
        }

        public void InitializeService(IItemBarcodeService itemBarcodeService)
        {
            _itemBarcodeService = itemBarcodeService;
        }

        private void btnIcBarkodUret_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (_itemBarcodeService == null) return;
            
            string generatedBarcode = _itemBarcodeService.GenerateInternalBarcode(CurrentModuleType);
            
            // Eğer zaten varsa ekleme
            foreach (var b in _barcodes)
            {
                if (b.BarcodeValue == generatedBarcode)
                {
                    XtraMessageBox.Show("Bu iç barkod zaten üretilmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            // Diğerlerini false yap
            foreach (var b in _barcodes) b.IsPrimary = false;
            
            var newBarcode = new ItemBarcodeListDto 
            { 
                RecordId = CurrentRecordId, 
                ModuleType = CurrentModuleType,
                BarcodeValue = generatedBarcode,
                BarcodeType = "Sistem (EAN-13)",
                Unit = "Adet",
                QuantityPerUnit = 1,
                WeightPerUnit = 0,
                IsPrimary = true
            };
            
            _barcodes.Add(newBarcode);
            gridViewBarcodes.RefreshData();
        }

        private void btnManuelBarkodEkle_Click(object sender, EventArgs e)
        {
            var newBarcode = new ItemBarcodeListDto 
            { 
                RecordId = CurrentRecordId, 
                ModuleType = CurrentModuleType,
                BarcodeType = "Manuel / Legacy",
                Unit = "Adet",
                QuantityPerUnit = 1,
                WeightPerUnit = 0,
                IsPrimary = true
            };
            
            // Diğerlerini false yap
            foreach (var b in _barcodes) b.IsPrimary = false;
            
            _barcodes.Add(newBarcode);
            gridViewBarcodes.RefreshData();
            
            // Odaklan
            gridViewBarcodes.FocusedRowHandle = gridViewBarcodes.RowCount - 1;
            gridViewBarcodes.FocusedColumn = gridViewBarcodes.Columns["BarcodeValue"];
            gridViewBarcodes.ShowEditor();
        }

        private void btnTedarikciBarkoduOku_Click(object sender, EventArgs e)
        {
            var newBarcode = new ItemBarcodeListDto 
            { 
                RecordId = CurrentRecordId, 
                ModuleType = CurrentModuleType,
                BarcodeType = "Tedarikçi (EAN-13)",
                Unit = "Adet",
                QuantityPerUnit = 1,
                WeightPerUnit = 0,
                IsPrimary = false
            };
            
            _barcodes.Add(newBarcode);
            gridViewBarcodes.RefreshData();
            
            // Odaklan
            gridViewBarcodes.FocusedRowHandle = gridViewBarcodes.RowCount - 1;
            gridViewBarcodes.FocusedColumn = gridViewBarcodes.Columns["BarcodeValue"];
            gridViewBarcodes.ShowEditor();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridViewBarcodes.GetFocusedRow() is ItemBarcodeListDto current)
            {
                if (XtraMessageBox.Show("Seçili barkodu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _barcodes.Remove(current);
                }
            }
        }

        private async void btnEtiketYazdir_Click(object sender, EventArgs e)
        {
            if (gridViewBarcodes.GetFocusedRow() is ItemBarcodeListDto current)
            {
                if (string.IsNullOrEmpty(current.BarcodeValue))
                {
                    XtraMessageBox.Show("Yazdırılacak geçerli bir barkod yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var printService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Common.IBarcodePrintService>();
                    await printService.PrintBarcodeAsync(current.BarcodeValue, current.Unit ?? "Adet", current.QuantityPerUnit);
                    XtraMessageBox.Show("Etiket yazdırma işlemi başarıyla kuyruğa eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Yazdırma sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private bool _isDirty = false;
        public event EventHandler OnDirtyChanged;

        public void PostGridChanges()
        {
            gridViewBarcodes.CloseEditor();
            gridViewBarcodes.UpdateCurrentRow();
        }

        public bool IsDirty() => _isDirty;

        private void SetDirty(bool dirty)
        {
            if (_isDirty != dirty)
            {
                _isDirty = dirty;
                OnDirtyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Kaydet(long recordId)
        {
            if (_itemBarcodeService == null) return;
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Prevent UI from updating during batch operation
            PostGridChanges();

            var existingBarcodes = _itemBarcodeService.GetBarcodes(recordId, CurrentModuleType);

            // 1. Delete removed barcodes
            var idsToDelete = new List<long>();
            foreach (var existing in existingBarcodes)
            {
                bool stillExists = false;
                foreach (var current in _barcodes)
                {
                    if (current.Id == existing.Id)
                    {
                        stillExists = true;
                        break;
                    }
                }
                
                if (!stillExists)
                {
                    idsToDelete.Add(existing.Id);
                }
            }
            
            if (idsToDelete.Any())
            {
                _itemBarcodeService.BulkDelete(idsToDelete);
            }

            // 2. Insert or Update barcodes
            var itemsToInsert = new List<ItemBarcodeDto>();
            var itemsToUpdate = new List<ItemBarcodeDto>();

            foreach (var current in _barcodes)
            {
                current.RecordId = recordId;
                current.ModuleType = CurrentModuleType;

                var dto = _mapper.Map<ItemBarcodeDto>(current);

                if (current.Id <= 0)
                {
                    itemsToInsert.Add(dto);
                    // DTO'nun Id'si serviste atanıp UI listesine de yansısın diye:
                    // Ama WinForms'ta listeyi yeniden yüklemek en temizi.
                }
                else
                {
                    itemsToUpdate.Add(dto);
                }
            }

            if (itemsToInsert.Any())
            {
                _itemBarcodeService.BulkInsert(itemsToInsert);
            }

            if (itemsToUpdate.Any())
            {
                _itemBarcodeService.BulkUpdate(itemsToUpdate);
            }

            // 3. Refresh UI from DB to get generated IDs properly
            var data = _itemBarcodeService.GetBarcodes(recordId, CurrentModuleType);
            _barcodes.Clear();
            foreach(var d in data) _barcodes.Add(d);
            
            SetDirty(false);
        }
    }
}

