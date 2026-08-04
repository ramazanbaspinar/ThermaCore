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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.PlastikParcaMaliyetForms
{
    public partial class PlastikParcaMaliyetEditForm : BaseMaliyetEditForm
    {
        private readonly IPlasticPartService _plasticPartService;

        public PlastikParcaMaliyetEditForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.PlastikParcaMaliyetleri;

            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _plasticPartService = Program.ServiceProvider.GetService<IPlasticPartService>();
            }
        }

        protected override void MalzemeListesiniDoldur()
        {
            if (_plasticPartService != null && _materialCostService != null)
            {
                var butunParcalar = _plasticPartService.GetAll().ToList();
                
                // Zaten maliyeti girilmiş parçaların ID listesi
                var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.PlastikParcaMaliyetleri);
                var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();

                if (Id == 0)
                {
                    // Yeni Kayıt: Önceden girilenleri listeden çıkar
                    butunParcalar = butunParcalar.Where(x => !girilmisIdler.Contains(x.Id)).ToList();
                }
                else
                {
                    // Düzeltme: Önceden girilenleri çıkar, AMA kendi ID'sini listede tut
                    long currentMaterialId = 0;
                    if (CurrentEntity is ThermaCore.Application.DTOs.Production.MaterialCostDto dto)
                    {
                        currentMaterialId = dto.MaterialId;
                    }
                    else if (OldEntity is ThermaCore.Application.DTOs.Production.MaterialCostDto oldDto)
                    {
                        currentMaterialId = oldDto.MaterialId;
                    }

                    butunParcalar = butunParcalar.Where(x => !girilmisIdler.Contains(x.Id) || x.Id == currentMaterialId).ToList();
                }

                glfMalzemeSecimi.Properties.DataSource = butunParcalar;
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
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.PlastikParcaForms.PlastikParcaListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                
                if (_materialCostService != null)
                {
                    var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.PlastikParcaMaliyetleri);
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