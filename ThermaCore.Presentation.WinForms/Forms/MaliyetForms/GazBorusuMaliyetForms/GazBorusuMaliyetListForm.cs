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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.GazBorusuMaliyetForms
{
    public partial class GazBorusuMaliyetListForm : BaseMaliyetListForm
    {
        public GazBorusuMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.GazBorusuMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<GazBorusuMaliyetEditForm>();
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
            var boruService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IGasPipeService>();
            if (boruService != null)
            {
                var borular = boruService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var boru = borular.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (boru != null)
                    {
                        item.MaterialName = boru.Name;
                    }
                }
            }
        }
    }
}