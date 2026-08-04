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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.RakorMaliyetForms
{
    public partial class RakorMaliyetListForm : BaseMaliyetListForm
    {
        public RakorMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.RakorMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<RakorMaliyetEditForm>();
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
            var rakorService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Definitions.IFittingService>();
            if (rakorService != null)
            {
                var rakorlar = rakorService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var rakor = rakorlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (rakor != null)
                    {
                        item.MaterialName = rakor.Name;
                    }
                }
            }
        }
    }
}