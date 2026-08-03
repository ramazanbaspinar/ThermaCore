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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.LambaMaliyetForms
{
    public partial class LambaMaliyetListForm : BaseMaliyetListForm
    {
        public LambaMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.LambaMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<LambaMaliyetEditForm>();
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
            var lambaService = Program.ServiceProvider.GetService<IOvenLampService>();
            if (lambaService != null)
            {
                var lambalar = lambaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var lamba = lambalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (lamba != null)
                    {
                        item.MaterialName = lamba.Name;
                    }
                }
            }
        }
    }
}