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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AteslemeTrafosuMaliyetForms
{
    public partial class AteslemeTrafosuMaliyetListForm : BaseMaliyetListForm
    {
        public AteslemeTrafosuMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.AteslemeTrafosuMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<AteslemeTrafosuMaliyetEditForm>();
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
            var trafoService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IIgnitionTransformerService>();
            if (trafoService != null)
            {
                var trafolar = trafoService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var trafo = trafolar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (trafo != null)
                    {
                        item.MaterialName = trafo.Name;
                    }
                }
            }
        }
    }
}
