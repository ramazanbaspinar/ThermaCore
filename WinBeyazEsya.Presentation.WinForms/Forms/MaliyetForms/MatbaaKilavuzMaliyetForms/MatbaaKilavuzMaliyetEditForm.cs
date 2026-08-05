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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MatbaaKilavuzMaliyetForms
{
    public partial class MatbaaKilavuzMaliyetEditForm : BaseMaliyetEditForm
    {
        private readonly IManualService _matbaaService;

        public MatbaaKilavuzMaliyetEditForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MatbaaKilavuzMaliyetleri;

            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _matbaaService = Program.ServiceProvider.GetService<IManualService>();
            }
        }

        protected override void MalzemeListesiniDoldur()
        {
            if (_matbaaService != null && _materialCostService != null)
            {
                var butunMatbaalar = _matbaaService.GetAll().ToList();
                
                var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.MatbaaKilavuzMaliyetleri);
                var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();

                if (Id == 0)
                {
                    butunMatbaalar = butunMatbaalar.Where(x => !girilmisIdler.Contains(x.Id)).ToList();
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

                    butunMatbaalar = butunMatbaalar.Where(x => !girilmisIdler.Contains(x.Id) || x.Id == currentMaterialId).ToList();
                }

                glfMalzemeSecimi.Properties.DataSource = butunMatbaalar;
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
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms.MatbaaKilavuzListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                
                if (_materialCostService != null)
                {
                    var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.MatbaaKilavuzMaliyetleri);
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
