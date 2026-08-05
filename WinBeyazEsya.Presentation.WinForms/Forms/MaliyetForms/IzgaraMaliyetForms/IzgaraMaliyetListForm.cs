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
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzgaraMaliyetForms
{
    public partial class IzgaraMaliyetListForm : BaseMaliyetListForm
    {
        public IzgaraMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.IzgaraMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<IzgaraMaliyetEditForm>();
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
            var izgaraService = Program.ServiceProvider.GetService<IGridService>();
            if (izgaraService != null)
            {
                var izgaralar = izgaraService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var izgara = izgaralar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (izgara != null)
                    {
                        item.MaterialName = izgara.Name;
                    }
                }
            }
        }
    }
}
