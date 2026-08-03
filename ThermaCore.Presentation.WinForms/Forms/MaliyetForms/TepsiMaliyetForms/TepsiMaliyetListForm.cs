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
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.TepsiMaliyetForms
{
    public partial class TepsiMaliyetListForm : BaseMaliyetListForm
    {
        public TepsiMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.TepsiMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<TepsiMaliyetEditForm>();
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
            var tepsiService = Program.ServiceProvider.GetService<ITrayService>();
            if (tepsiService != null)
            {
                var tepsiler = tepsiService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var tepsi = tepsiler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (tepsi != null)
                    {
                        item.MaterialName = tepsi.Name;
                    }
                }
            }
        }
    }
}