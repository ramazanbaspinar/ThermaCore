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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermokuplMaliyetForms
{
    public partial class TermokuplMaliyetListForm : BaseMaliyetListForm
    {
        public TermokuplMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.TermokuplMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<TermokuplMaliyetEditForm>();
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
            var thermocoupleService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IThermocoupleService>();
            if (thermocoupleService != null)
            {
                var termokupllar = thermocoupleService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var termokupl = termokupllar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (termokupl != null)
                    {
                        item.MaterialName = termokupl.Name;
                    }
                }
            }
        }
    }
}
