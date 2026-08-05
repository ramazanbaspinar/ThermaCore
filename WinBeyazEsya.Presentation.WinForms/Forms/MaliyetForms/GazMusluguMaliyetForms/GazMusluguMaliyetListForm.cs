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
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazMusluguMaliyetForms
{
    public partial class GazMusluguMaliyetListForm : BaseMaliyetListForm
    {
        public GazMusluguMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.GazMusluguMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<GazMusluguMaliyetEditForm>();
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

        protected override void MalzemeAdlariniDoldur(IEnumerable<WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            var gasValveService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IGasValveService>();
            if (gasValveService != null)
            {
                var musluklar = gasValveService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var musluk = musluklar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (musluk != null)
                    {
                        item.MaterialName = musluk.Name;
                    }
                }
            }
        }
    }
}
