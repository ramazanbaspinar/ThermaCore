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
using ThermaCore.Application.Interfaces.Production;
using Microsoft.Extensions.DependencyInjection;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.GazMusluguMaliyetForms
{
    public partial class GazMusluguMaliyetEditForm : BaseMaliyetEditForm
    {
        private readonly IGasValveService _gasValveService;

        public GazMusluguMaliyetEditForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.GazMusluguMaliyetleri;

            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _gasValveService = Program.ServiceProvider.GetService<IGasValveService>();
            }
        }

        protected override void MalzemeListesiniDoldur()
        {
            if (_gasValveService != null && _materialCostService != null)
            {
                // Notice the usage of GetAll() according to the service implementation
                var butunMusluklar = _gasValveService.GetAll().ToList();
                
                // Zaten maliyeti girilmiş gaz musluklarının ID listesi
                var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.GazMusluguMaliyetleri);
                var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();

                if (Id == 0)
                {
                    // Yeni Kayıt: Önceden girilenleri listeden çıkar
                    butunMusluklar = butunMusluklar.Where(x => !girilmisIdler.Contains(x.Id)).ToList();
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

                    butunMusluklar = butunMusluklar.Where(x => !girilmisIdler.Contains(x.Id) || x.Id == currentMaterialId).ToList();
                }

                glfMalzemeSecimi.Properties.DataSource = butunMusluklar;
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
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.GazForms.GazListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                
                if (_materialCostService != null)
                {
                    var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.GazMusluguMaliyetleri);
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