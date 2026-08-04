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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.VidaMaliyetForms
{
    public partial class VidaMaliyetListForm : BaseMaliyetListForm
    {
        public VidaMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.VidaMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<VidaMaliyetEditForm>();
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
            var vidaService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IScrewService>();
            if (vidaService != null)
            {
                var vidalar = vidaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var vida = vidalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (vida != null)
                    {
                        item.MaterialName = vida.Name;
                    }
                }
            }
        }
    }
}