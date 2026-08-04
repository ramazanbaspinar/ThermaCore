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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.CamMaliyetForms
{
    public partial class CamMaliyetListForm : BaseMaliyetListForm
    {
        public CamMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.CamMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<CamMaliyetEditForm>();
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
            var camService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IOvenGlassService>();
            if (camService != null)
            {
                var camlar = camService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var cam = camlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (cam != null)
                    {
                        item.MaterialName = cam.Name;
                    }
                }
            }
        }
    }
}