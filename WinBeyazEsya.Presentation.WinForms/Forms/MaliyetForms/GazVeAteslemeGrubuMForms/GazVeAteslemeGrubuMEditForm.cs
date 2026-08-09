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
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.Interfaces.Definitions;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazVeAteslemeGrubuMForms
{
    public partial class GazVeAteslemeGrubuMEditForm : BaseMaliyetEditForm
    {
        private readonly IGasAndIgnitionGroupService _gasAndIgnitionGroupService;

        public GazVeAteslemeGrubuMEditForm(
            IServiceProvider serviceProvider, 
            WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService materialCostService, 
            WinBeyazEsya.Application.Interfaces.System.IExchangeRateService exchangeRateService, 
            IGasAndIgnitionGroupService gasAndIgnitionGroupService) 
            : base(serviceProvider, materialCostService, exchangeRateService)
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.GazVeAteslemeGrubuMaliyetleri;
            RequiresCodeTemplate = true;
            _gasAndIgnitionGroupService = gasAndIgnitionGroupService;
        }

        protected override void NesneyiKontrollereBagla()
        {
            base.NesneyiKontrollereBagla();
            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void MalzemeListesiniDoldur()
        {
            if (_gasAndIgnitionGroupService != null && _materialCostService != null)
            {
                var butunMalzemeler = _gasAndIgnitionGroupService.GetAll().AsQueryable();
                
                var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.GazVeAteslemeGrubuMaliyetleri);
                var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();

                if (Id == 0)
                {
                    butunMalzemeler = butunMalzemeler.Where(x => !girilmisIdler.Contains(x.Id));
                }
                else
                {
                    long currentMaterialId = 0;
                    if (CurrentEntity is WinBeyazEsya.Application.DTOs.Production.MaterialCostDto dto)
                    {
                        currentMaterialId = dto.MaterialId;
                    }
                    else if (OldEntity is WinBeyazEsya.Application.DTOs.Production.MaterialCostDto oldDto)
                    {
                        currentMaterialId = oldDto.MaterialId;
                    }

                    butunMalzemeler = butunMalzemeler.Where(x => !girilmisIdler.Contains(x.Id) || x.Id == currentMaterialId);
                }

                glfMalzemeSecimi.Properties.DataSource = System.Linq.Enumerable.ToList(butunMalzemeler);
                glfMalzemeSecimi.Properties.ValueMember = "Id";
                glfMalzemeSecimi.Properties.DisplayMember = "Name";
            }
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            if (glfMalzemeSecimi != null)
            {
                glfMalzemeSecimi.SearchButtonClicked += glfMalzemeSecimi_SearchButtonClicked;
            }
        }

        private void glfMalzemeSecimi_SearchButtonClicked(object? sender, EventArgs e)
        {
            if (_serviceProvider == null) return;
            using (var scope = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.CreateScope(_serviceProvider))
            {
                using (var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazveAteslemeGrubuForms.GazveAteslemeGrubuListForm>(scope.ServiceProvider))
                {
                    if (form != null)
                    {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                
                if (_materialCostService != null)
                {
                    var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.GazVeAteslemeGrubuMaliyetleri);
                    var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();
                    
                    if (Id > 0)
                    {
                        long currentMaterialId = 0;
                        if (CurrentEntity is WinBeyazEsya.Application.DTOs.Production.MaterialCostDto dto)
                            currentMaterialId = dto.MaterialId;
                        girilmisIdler.Remove(currentMaterialId);
                    }
                    
                    form.ListeDisiTutulacakKayitlar = girilmisIdler;
                }

                form.ShowDialog();
                
                MalzemeListesiniDoldur();
                if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glfMalzemeSecimi.EditValue = secilenId;
                }
            }
                }
            }
        }
    }
}



