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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajMalzemesiMaliyetForms
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
            var form = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajMaliyetForms.AmbalajMalzemesiMaliyetEditForm>();
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
            var ambalajService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IPackagingMaterialService>();
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
