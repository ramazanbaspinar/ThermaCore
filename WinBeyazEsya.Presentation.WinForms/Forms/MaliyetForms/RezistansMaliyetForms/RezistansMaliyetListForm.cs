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
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RezistansMaliyetForms
{
    public partial class RezistansMaliyetListForm : BaseMaliyetListForm
    {
        public RezistansMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.RezistansMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<RezistansMaliyetEditForm>();
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
            var rezistansService = Program.ServiceProvider.GetService<IHeatingElementService>();
            if (rezistansService != null)
            {
                var rezistanslar = rezistansService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var rezistans = rezistanslar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (rezistans != null)
                    {
                        item.MaterialName = rezistans.Name;
                    }
                }
            }
        }
    }
}
