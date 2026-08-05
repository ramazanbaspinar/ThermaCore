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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MatbaaKilavuzMaliyetForms
{
    public partial class MatbaaKilavuzMaliyetListForm : BaseMaliyetListForm
    {
        public MatbaaKilavuzMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MatbaaKilavuzMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<MatbaaKilavuzMaliyetEditForm>();
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
            var matbaaService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IManualService>();
            if (matbaaService != null)
            {
                var matbaalar = matbaaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var matbaa = matbaalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (matbaa != null)
                    {
                        item.MaterialName = matbaa.Name;
                    }
                }
            }
        }
    }
}
