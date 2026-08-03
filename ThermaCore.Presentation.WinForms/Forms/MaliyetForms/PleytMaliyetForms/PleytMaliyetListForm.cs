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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.PleytMaliyetForms
{
    public partial class PleytMaliyetListForm : BaseMaliyetListForm
    {
        public PleytMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.PleytMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<PleytMaliyetEditForm>();
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
            var hotplateService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IHotplateService>();
            if (hotplateService != null)
            {
                var pleytler = hotplateService.GetAllList().ToList();
                foreach (var item in liste)
                {
                    var pleyt = pleytler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (pleyt != null)
                    {
                        item.MaterialName = pleyt.Name;
                    }
                }
            }
        }
    }
}