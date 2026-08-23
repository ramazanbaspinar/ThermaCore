using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinalmaForms
{
    public partial class SatinalmaSiparisAktarListForm : BaseListForm
    {
        private WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService _purchaseOrderService = null!;
        public long SupplierId { get; set; }
        public List<long> ExcludedLineIds { get; set; } = new List<long>();
        public List<WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderLineTransferListDto> SelectedLines { get; private set; } = new List<WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderLineTransferListDto>();
        
        private List<MaterialLookupDto> _allMaterials;
        private bool _isSecButton = false;
        
        private class MaterialLookupDto
        {
            public long Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        public SatinalmaSiparisAktarListForm()
        {
            InitializeComponent();
        }

        protected override void DegiskenleriDoldur()
        {
            if (IsDesignMode) return;
            
            _purchaseOrderService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService>();
            
            Tablo = myGridView1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.SatinalmaSiparisleri;
            
            // Base formun MultiSelect özelliğini true yapıyoruz
            this.MultiSelect = true;
            
            if (longNavigator1 != null)
            {
                Navigator = longNavigator1.Navigator;
            }
            
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnDuzelt != null) btnDuzelt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSec != null) 
            {
                btnSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnSec.ItemClick += BtnSec_ItemClick;
            }
            if (btnAktifPasifKayitlar != null) btnAktifPasifKayitlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnDisariAktar != null) btnDisariAktar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnFavorilereEkle != null) btnFavorilereEkle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (Tablo != null)
            {
                RowSelect = new WinBeyazEsya.Presentation.WinForms.Helpers.SelectRowFunctions(Tablo);
                Tablo.OptionsSelection.MultiSelect = true;
                Tablo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                Tablo.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                Tablo.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
                
                // Hücre odaklanmasını kapat, sadece satıra odaklan
                Tablo.OptionsSelection.EnableAppearanceFocusedCell = false;
                Tablo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                
                Tablo.MouseDown += Tablo_MouseDown;
                Tablo.KeyDown += Tablo_KeyDown_Custom;
            }
        }

        private void Tablo_KeyDown_Custom(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (Tablo != null && Tablo.FocusedRowHandle >= 0)
                {
                    bool isSelected = Tablo.IsRowSelected(Tablo.FocusedRowHandle);
                    if (isSelected)
                    {
                        Tablo.UnselectRow(Tablo.FocusedRowHandle);
                    }
                    else
                    {
                        Tablo.SelectRow(Tablo.FocusedRowHandle);
                    }
                    e.Handled = true;
                }
            }
        }

        private void BtnSec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _isSecButton = true;
            SelectEntity();
            _isSecButton = false;
        }

        private void Tablo_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                // Çift tıklayınca seçme özelliğini bu form için devre dışı bırakıyoruz.
                if (e is DevExpress.Utils.DXMouseEventArgs dxArgs)
                {
                    dxArgs.Handled = true;
                }
            }
        }

        protected override void Listele()
        {
            if (_purchaseOrderService == null) return;
            
            var list = _purchaseOrderService.GetOpenOrderLinesAsync(SupplierId).GetAwaiter().GetResult();
            
            // Mevcut irsaliyede seçilmiş olanları filtrele
            if (ExcludedLineIds != null && ExcludedLineIds.Any())
            {
                list = list.Where(x => !ExcludedLineIds.Contains(x.PurchaseOrderLineId)).ToList();
            }
            
            LoadAllMaterials();
            foreach(var item in list)
            {
                if (_allMaterials != null)
                {
                    var mat = _allMaterials.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (mat != null)
                        item.MaterialName = mat.Name;
                }
            }

            if (Tablo != null && Tablo.GridControl != null)
            {
                Tablo.GridControl.DataSource = list;
                
                // Birim Fiyat kolonunu n4 yapalım
                if (Tablo.Columns["UnitPrice"] != null)
                {
                    Tablo.Columns["UnitPrice"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    Tablo.Columns["UnitPrice"].DisplayFormat.FormatString = "n4";
                }
            }
        }
        
        private void LoadAllMaterials()
        {
            _allMaterials = new List<MaterialLookupDto>();
            if (Program.ServiceProvider == null || DesignMode) return;

            var metalService = (WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService));
            var electricService = (WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService));
            var plasticService = (WinBeyazEsya.Application.Interfaces.Definitions.IPlasticAndVisualPartsGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IPlasticAndVisualPartsGroupService));
            var chemicalService = (WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService));
            var mechanicService = (WinBeyazEsya.Application.Interfaces.Definitions.IMechanicalAndHardwareGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IMechanicalAndHardwareGroupService));
            var packService = (WinBeyazEsya.Application.Interfaces.Definitions.IPackagingAndPrintingGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IPackagingAndPrintingGroupService));
            var wireService = (WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService));
            var otherService = (WinBeyazEsya.Application.Interfaces.Definitions.IOtherMaterialGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IOtherMaterialGroupService));

            if (metalService != null) _allMaterials.AddRange(metalService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (electricService != null) _allMaterials.AddRange(electricService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (plasticService != null) _allMaterials.AddRange(plasticService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (chemicalService != null) _allMaterials.AddRange(chemicalService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (mechanicService != null) _allMaterials.AddRange(mechanicService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (packService != null) _allMaterials.AddRange(packService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (wireService != null) _allMaterials.AddRange(wireService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (otherService != null) _allMaterials.AddRange(otherService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
        }

        protected override void SelectEntity()
        {
            if (!_isSecButton) return;
            if (Tablo == null) return;

            var selectedRows = Tablo.GetSelectedRows();
            foreach (var rowHandle in selectedRows)
            {
                if (Tablo.GetRow(rowHandle) is WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderLineTransferListDto row)
                {
                    SelectedLines.Add(row);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            // Sadece bu formda "Kayıt Bilgileri" sağ tık menüsünü gizleyelim
            if (SagTikMenu != null)
            {
                foreach (DevExpress.XtraBars.BarItemLink link in SagTikMenu.ItemLinks)
                {
                    if (link.Item != null && link.Item.Name == "btnKayitBilgileri")
                    {
                        link.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
            }
        }
    }
}