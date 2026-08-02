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
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.SacMaliyetForms
{
    public partial class SacMaliyetListForm : BaseMaliyetListForm
    {
        public SacMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.SacMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<SacMaliyetEditForm>();
            if (form != null)
            {
                form.IdAtaVeAc(id);
                Listele();
                if (form.Id > 0)
                {
                    Tablo.RowFocus("Id", form.Id);
                }
            }
        }

        protected override void MalzemeAdlariniDoldur(IEnumerable<ThermaCore.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            var sheetMetalService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.ISheetMetalService>();
            if (sheetMetalService != null)
            {
                var saclar = sheetMetalService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var sac = saclar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (sac != null)
                    {
                        item.MaterialName = sac.Name;
                    }
                }
            }
        }
    }
}