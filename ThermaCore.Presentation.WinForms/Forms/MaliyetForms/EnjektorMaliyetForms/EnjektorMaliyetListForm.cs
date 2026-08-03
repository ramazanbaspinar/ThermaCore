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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.EnjektorMaliyetForms
{
    public partial class EnjektorMaliyetListForm : BaseMaliyetListForm
    {
        public EnjektorMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.EnjektorMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<EnjektorMaliyetEditForm>();
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
            var injectorService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IInjectorService>();
            if (injectorService != null)
            {
                var enjektorler = injectorService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var enjektor = enjektorler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (enjektor != null)
                    {
                        item.MaterialName = enjektor.Name;
                    }
                }
            }
        }
    }
}