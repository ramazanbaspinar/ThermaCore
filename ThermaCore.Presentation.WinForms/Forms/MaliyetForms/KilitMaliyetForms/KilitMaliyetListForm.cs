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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.KilitMaliyetForms
{
    public partial class KilitMaliyetListForm : BaseMaliyetListForm
    {
        public KilitMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.KilitMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<KilitMaliyetEditForm>();
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
            var kilitService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Definitions.ILockService>();
            if (kilitService != null)
            {
                var kilitler = kilitService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var kilit = kilitler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (kilit != null)
                    {
                        item.MaterialName = kilit.Name;
                    }
                }
            }
        }
    }
}