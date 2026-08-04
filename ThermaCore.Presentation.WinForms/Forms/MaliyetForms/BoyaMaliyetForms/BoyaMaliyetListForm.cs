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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.BoyaMaliyetForms
{
    public partial class BoyaMaliyetListForm : BaseMaliyetListForm
    {
        public BoyaMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.BoyaMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<BoyaMaliyetEditForm>();
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
            var boyaService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IBoyaService>();
            if (boyaService != null)
            {
                var boyalar = boyaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var boya = boyalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (boya != null)
                    {
                        item.MaterialName = boya.Name;
                    }
                }
            }
        }
    }
}