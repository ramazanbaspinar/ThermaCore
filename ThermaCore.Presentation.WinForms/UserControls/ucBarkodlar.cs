using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    public partial class ucBarkodlar : XtraUserControl
    {
        private IItemBarcodeService _itemBarcodeService;
        private BindingList<ItemBarcodeListDto> _barcodes = new BindingList<ItemBarcodeListDto>();

        public long CurrentRecordId { get; set; }
        public string CurrentRecordCode { get; set; }
        public ModuleType CurrentModuleType { get; set; }

        public ucBarkodlar()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                gridControlBarcodes.DataSource = _barcodes;
                
                gridViewBarcodes.ShowingEditor += GridViewBarcodes_ShowingEditor;
                gridViewBarcodes.CellValueChanged += GridViewBarcodes_CellValueChanged;
            }
        }

        private void GridViewBarcodes_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridViewBarcodes.FocusedColumn.FieldName == "BarcodeValue" || 
                gridViewBarcodes.FocusedColumn.FieldName == "BarcodeType")
            {
                var row = gridViewBarcodes.GetFocusedRow() as ItemBarcodeListDto;
                if (row != null && row.BarcodeType == "Sistem (Code-128)")
                {
                    e.Cancel = true;
                }
            }
        }

        private void GridViewBarcodes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
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
                gridControlBarcodes.DataSource = _barcodes;
            }
            else
            {
                _barcodes.Clear();
            }
        }

        public void InitializeService(IItemBarcodeService itemBarcodeService)
        {
            _itemBarcodeService = itemBarcodeService;
        }

        private void btnIcBarkodUret_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
            string prefix = "SYS";
            try
            {
                var paramService = Program.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Management.ISystemParameterService>();
                var param = paramService.GetSystemParameterAsync().GetAwaiter().GetResult();
                if (!string.IsNullOrEmpty(param?.CompanyBarcodePrefix))
                {
                    prefix = param.CompanyBarcodePrefix;
                }
            }
            catch { }
            
            string generatedBarcode = $"{prefix}-{CurrentRecordCode}";
            
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
                BarcodeType = "Sistem (Code-128)",
                IsPrimary = true
            };
            
            _barcodes.Add(newBarcode);
            gridViewBarcodes.RefreshData();
        }

        private void btnTedarikciBarkoduOku_Click(object sender, EventArgs e)
        {
            var newBarcode = new ItemBarcodeListDto 
            { 
                RecordId = CurrentRecordId, 
                ModuleType = CurrentModuleType,
                BarcodeType = "Tedarikçi (EAN-13)",
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
                _barcodes.Remove(current);
            }
        }
        
        public void Kaydet(long recordId)
        {
            if (_itemBarcodeService == null) return;
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Prevent UI from updating during batch operation
            gridViewBarcodes.CloseEditor();
            gridViewBarcodes.UpdateCurrentRow();

            var existingBarcodes = _itemBarcodeService.GetBarcodes(recordId, CurrentModuleType);

            // 1. Delete removed barcodes
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
                    _itemBarcodeService.Delete(existing.Id);
                }
            }

            // 2. Insert or Update barcodes
            foreach (var current in _barcodes)
            {
                current.RecordId = recordId;
                current.ModuleType = CurrentModuleType;

                var dto = new ItemBarcodeDto
                {
                    Id = current.Id,
                    BarcodeValue = current.BarcodeValue,
                    BarcodeType = current.BarcodeType,
                    RecordId = current.RecordId,
                    ModuleType = current.ModuleType,
                    Description = current.Description,
                    IsPrimary = current.IsPrimary
                };

                if (current.Id <= 0)
                {
                    _itemBarcodeService.Insert(dto);
                }
                else
                {
                    _itemBarcodeService.Update(dto);
                }
            }
        }
    }
}
