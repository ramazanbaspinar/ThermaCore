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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.KabloMaliyetForms
{
    public partial class KabloMaliyetListForm : BaseMaliyetListForm
    {
        public KabloMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.KabloMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<KabloMaliyetEditForm>();
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
            var kabloService = Program.ServiceProvider.GetService<ICableService>();
            if (kabloService != null)
            {
                var kablolar = kabloService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var kablo = kablolar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (kablo != null)
                    {
                        item.MaterialName = kablo.Name;
                    }
                }
            }
        }
    }
}