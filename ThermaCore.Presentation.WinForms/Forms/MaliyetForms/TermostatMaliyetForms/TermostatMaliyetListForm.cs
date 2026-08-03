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
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.TermostatMaliyetForms
{
    public partial class TermostatMaliyetListForm : BaseMaliyetListForm
    {
        public TermostatMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.TermostatMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<TermostatMaliyetEditForm>();
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
            var termostatService = Program.ServiceProvider.GetService<IThermostatService>();
            if (termostatService != null)
            {
                var termostatlar = termostatService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var termostat = termostatlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (termostat != null)
                    {
                        item.MaterialName = termostat.Name;
                    }
                }
            }
        }
    }
}