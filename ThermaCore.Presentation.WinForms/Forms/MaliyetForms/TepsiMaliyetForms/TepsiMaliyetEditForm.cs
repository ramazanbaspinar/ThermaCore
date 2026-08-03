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
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Domain.Enums;
using ThermaCore.Application.Interfaces.Definitions;
using Microsoft.Extensions.DependencyInjection;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.TepsiMaliyetForms
{
    public partial class TepsiMaliyetEditForm : BaseMaliyetEditForm
    {
        private readonly ITrayService _tepsiService;

        public TepsiMaliyetEditForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.TepsiMaliyetleri;

            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _tepsiService = Program.ServiceProvider.GetService<ITrayService>();
            }
        }

        protected override void MalzemeListesiniDoldur()
        {
            if (_tepsiService != null && _materialCostService != null)
            {
                var butunTepsiler = _tepsiService.GetAll().ToList();
                
                var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.TepsiMaliyetleri);
                var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();

                if (Id == 0)
                {
                    butunTepsiler = butunTepsiler.Where(x => !girilmisIdler.Contains(x.Id)).ToList();
                }
                else
                {
                    long currentMaterialId = 0;
                    if (CurrentEntity is ThermaCore.Application.DTOs.Production.MaterialCostDto dto)
                    {
                        currentMaterialId = dto.MaterialId;
                    }
                    else if (OldEntity is ThermaCore.Application.DTOs.Production.MaterialCostDto oldDto)
                    {
                        currentMaterialId = oldDto.MaterialId;
                    }

                    butunTepsiler = butunTepsiler.Where(x => !girilmisIdler.Contains(x.Id) || x.Id == currentMaterialId).ToList();
                }

                glfMalzemeSecimi.Properties.DataSource = butunTepsiler;
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
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.TepsiForms.TepsiListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                
                if (_materialCostService != null)
                {
                    var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.TepsiMaliyetleri);
                    var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();
                    
                    if (Id > 0)
                    {
                        long currentMaterialId = 0;
                        if (CurrentEntity is ThermaCore.Application.DTOs.Production.MaterialCostDto dto)
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