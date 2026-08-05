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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ContaMaliyetForms
{
    public partial class ContaMaliyetListForm : BaseMaliyetListForm
    {
        public ContaMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.ContaMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<ContaMaliyetEditForm>();
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
            var contaService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IGasketService>();
            if (contaService != null)
            {
                var contalar = contaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var conta = contalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (conta != null)
                    {
                        item.MaterialName = conta.Name;
                    }
                }
            }
        }
    }
}
