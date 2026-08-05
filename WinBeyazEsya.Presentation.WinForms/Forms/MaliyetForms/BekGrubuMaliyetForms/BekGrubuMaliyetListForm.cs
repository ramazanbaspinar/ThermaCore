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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BekGrubuMaliyetForms
{
    public partial class BekGrubuMaliyetListForm : BaseMaliyetListForm
    {
        public BekGrubuMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.BekMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<BekGrubuMaliyetEditForm>();
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
            var burnerService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IBurnerService>();
            if (burnerService != null)
            {
                var bekler = burnerService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var bek = bekler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (bek != null)
                    {
                        item.MaterialName = bek.Name;
                    }
                }
            }
        }
    }
}
