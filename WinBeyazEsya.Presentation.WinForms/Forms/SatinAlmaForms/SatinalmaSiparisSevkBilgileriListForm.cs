using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Purchasing;
using WinBeyazEsya.Application.Interfaces.Purchasing;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinAlmaForms
{
    public partial class SatinalmaSiparisSevkBilgileriListForm : BaseListForm
    {
        public long? PurchaseOrderId { get; set; }
        public long? PurchaseOrderLineId { get; set; }
        
        private readonly IServiceProvider? _serviceProvider;
        private IPurchaseReceiptService? _receiptService;

        public SatinalmaSiparisSevkBilgileriListForm()
        {
            InitializeComponent();
            _serviceProvider = Program.ServiceProvider;
            if (!DesignMode && _serviceProvider != null)
            {
                _receiptService = _serviceProvider.GetService<IPurchaseReceiptService>();
            }

            this.Shown += (s, e) =>
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (btnSec != null) btnSec.Visibility = BarItemVisibility.Never;
                    if (barEnter != null) barEnter.Visibility = BarItemVisibility.Never;
                    if (barEnterAciklama != null) barEnterAciklama.Visibility = BarItemVisibility.Never;
                }));
            };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri; 
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = false;

            if (btnYeni != null) btnYeni.Visibility = BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = BarItemVisibility.Never;
            if (btnDuzelt != null) btnDuzelt.Visibility = BarItemVisibility.Never;
            if (btnSec != null) btnSec.Visibility = BarItemVisibility.Never;
            if (btnFavorilereEkle != null) btnFavorilereEkle.Visibility = BarItemVisibility.Never;

            if (PurchaseOrderLineId.HasValue)
            {
                myGridView1.OptionsView.ShowFooter = true;
                colMiktar.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                colMiktar.SummaryItem.DisplayFormat = "{0:n2}";
            }
        }

        protected override void SelectEntity()
        {
            // Çift tıklandığında formun kapanmasını engelle
        }

        protected override void Listele()
        {
            if (_receiptService == null) return;
            
            var dispatchInfos = _receiptService.GetDispatchInfoAsync(PurchaseOrderId, PurchaseOrderLineId).GetAwaiter().GetResult().ToList();

            if (_serviceProvider != null)
            {
                var materials = LoadAllMaterials();
                var unitService = _serviceProvider.GetService<IUnitRepository>();
                
                foreach (var item in dispatchInfos)
                {
                    if (item.MaterialId > 0)
                    {
                        var material = materials.FirstOrDefault(x => x.Id == item.MaterialId);
                        if (material != null) item.MaterialName = material.Name ?? "";
                    }
                    if (unitService != null && item.UnitId > 0)
                    {
                        var unit = unitService.GetById(item.UnitId);
                        if (unit != null) item.UnitName = unit.Name ?? "";
                    }
                }
            }

            myGridControl1.DataSource = new BindingList<PurchaseOrderDispatchListDto>(dispatchInfos);
        }

        private System.Collections.Generic.List<MaterialLookupDto> LoadAllMaterials()
        {
            var allMaterials = new System.Collections.Generic.List<MaterialLookupDto>();
            if (_serviceProvider == null || DesignMode) return allMaterials;

            var metalService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService>();
            var electricService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService>();
            var plasticService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IPlasticAndVisualPartsGroupService>();
            var chemicalService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService>();
            var mechanicService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IMechanicalAndHardwareGroupService>();
            var packService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IPackagingAndPrintingGroupService>();
            var wireService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService>();
            var otherService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IOtherMaterialGroupService>();
            var rawService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IRawMaterialService>();

            if (metalService != null) allMaterials.AddRange(metalService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (electricService != null) allMaterials.AddRange(electricService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (plasticService != null) allMaterials.AddRange(plasticService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (chemicalService != null) allMaterials.AddRange(chemicalService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (mechanicService != null) allMaterials.AddRange(mechanicService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (packService != null) allMaterials.AddRange(packService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (wireService != null) allMaterials.AddRange(wireService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (otherService != null) allMaterials.AddRange(otherService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));
            if (rawService != null) allMaterials.AddRange(rawService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Name = x.Name }));

            return allMaterials;
        }
    }
}