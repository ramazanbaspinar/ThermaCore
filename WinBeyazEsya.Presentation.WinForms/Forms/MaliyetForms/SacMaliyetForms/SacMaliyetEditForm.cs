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
using WinBeyazEsya.Application.Interfaces.Production;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.SacMaliyetForms
{
    public partial class SacMaliyetEditForm : BaseMaliyetEditForm
    {
        private readonly ISheetMetalService _sheetMetalService;

        public SacMaliyetEditForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.SacMaliyetleri;

            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _sheetMetalService = Program.ServiceProvider.GetService<ISheetMetalService>();
            }
        }

        protected override void MalzemeListesiniDoldur()
        {
            if (_sheetMetalService != null && _materialCostService != null)
            {
                var butunSaclar = _sheetMetalService.GetAll().ToList();
                
                // Zaten maliyeti girilmiş sacların ID listesi
                var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.SacMaliyetleri);
                var girilmisIdler = girilmisMaliyetler.Select(x => x.MaterialId).ToList();

                if (Id == 0)
                {
                    // Yeni Kayıt: Önceden girilenleri listeden çıkar
                    butunSaclar = butunSaclar.Where(x => !girilmisIdler.Contains(x.Id)).ToList();
                }
                else
                {
                    // Düzeltme: Önceden girilenleri çıkar, AMA kendi ID'sini listede tut
                    long currentMaterialId = 0;
                    if (CurrentEntity is WinBeyazEsya.Application.DTOs.Production.MaterialCostDto dto)
                    {
                        currentMaterialId = dto.MaterialId;
                    }
                    else if (OldEntity is WinBeyazEsya.Application.DTOs.Production.MaterialCostDto oldDto)
                    {
                        currentMaterialId = oldDto.MaterialId;
                    }

                    butunSaclar = butunSaclar.Where(x => !girilmisIdler.Contains(x.Id) || x.Id == currentMaterialId).ToList();
                }

                glfMalzemeSecimi.Properties.DataSource = butunSaclar;
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
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.SacForms.SacListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                
                if (_materialCostService != null)
                {
                    var girilmisMaliyetler = _materialCostService.GetAllByMaterialType(ModuleType.SacMaliyetleri);
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
