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
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.FanMaliyetForms
{
    public partial class FanMaliyetEditForm : BaseMaliyetListForm
    {
        public FanMaliyetEditForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.FanMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<FanMaliyetListForm>();
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

        protected override void MalzemeAdlariniDoldur(IEnumerable<WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            var fanService = Program.ServiceProvider.GetService<IOvenFanService>();
            if (fanService != null)
            {
                var fanlar = fanService.GetAllList().ToList();
                foreach (var item in liste)
                {
                    var fan = fanlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (fan != null)
                    {
                        item.MaterialName = fan.Name;
                    }
                }
            }
        }
    }
}
