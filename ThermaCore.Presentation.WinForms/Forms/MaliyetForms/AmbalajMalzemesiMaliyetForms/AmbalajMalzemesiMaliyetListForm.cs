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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.AmbalajMalzemesiMaliyetForms
{
    public partial class AmbalajMalzemesiMaliyetListForm : BaseMaliyetListForm
    {
        public AmbalajMalzemesiMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.AmbalajMalzemesiMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.MaliyetForms.AmbalajMaliyetForms.AmbalajMalzemesiMaliyetEditForm>();
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
            var ambalajService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Definitions.IPackagingMaterialService>();
            if (ambalajService != null)
            {
                var ambalajlar = ambalajService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var ambalaj = ambalajlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (ambalaj != null)
                    {
                        item.MaterialName = ambalaj.Name;
                    }
                }
            }
        }
    }
}